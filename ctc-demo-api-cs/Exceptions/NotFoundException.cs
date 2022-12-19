using System;

namespace WYWM.CTC.API.Exceptions;

[Serializable]
public class NotFoundException : AppException
{
    public NotFoundException(string title, string message) : base(title, message)
    {
    }
}