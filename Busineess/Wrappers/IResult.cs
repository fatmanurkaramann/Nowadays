﻿namespace Business.Wrappers
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
