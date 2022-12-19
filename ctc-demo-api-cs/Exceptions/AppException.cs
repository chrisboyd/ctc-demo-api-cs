using System;

namespace WYWM.CTC.API.Exceptions;

public class AppException : Exception
{
    public AppException(string title, string message) : base(message) => Title = title;
    public string Title { get; set; }
}