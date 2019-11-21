using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Exceptions;


namespace ConsoleApp1
{
    public enum SeverityLevel
    {
        Trace = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4
    }
    public interface IReporter
    {
        void Report(Exception ex, string description, SeverityLevel level);
    }
}
