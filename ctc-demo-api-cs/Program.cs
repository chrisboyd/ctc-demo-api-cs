using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using WYWM.CTC.API.Activities.CourseReports.Infrastructure;
using WYWM.CTC.API.Activities.CourseReports.Services;
using WYWM.CTC.API.Activities.PerformanceObjectives.Infrastructure;
using WYWM.CTC.API.Activities.PerformanceObjectives.Services;
using WYWM.CTC.API.Behaviours;
using WYWM.CTC.API.Helpers;
using WYWM.CTC.API.Middleware;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo {Title = "ctc_demo_api_cs", Version = "v1"});
//     c.CustomSchemaIds(x => x.FullName);
//     c.DocumentFilter<JsonPatchDocumentFilter>();
//     c.EnableAnnotations();
// });
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IPerfObjectiveRepository, PerfObjectiveRepository>();

builder.Services.AddDbContext<CourseReportContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CourseReportConnection")));
builder.Services.AddScoped<ICourseReportRepository, CourseReportRepository>();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(Program))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CourseReportContext>();
    context.Database.Migrate();

    await CourseReportsDbInitializer.Initialize(context);
}
app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ctc_demo_api_cs v1"));
// }

app.UseHttpsRedirection();


app.UseAuthorization();
app.MapControllers();
app.Run();