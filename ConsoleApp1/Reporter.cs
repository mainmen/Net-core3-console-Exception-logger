using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Exceptions;
namespace ConsoleApp1
{
    class Reporter : IReporter
    {
        void IReporter.Report(Exception ex, string description, SeverityLevel level)
        {
            switch (level)
            {
                case SeverityLevel.Trace:
                    WriteLine(ex, ConsoleColor.Cyan, $"Trace: {description}");
                    break;     
                case SeverityLevel.Info:
                    WriteLine(ex, ConsoleColor.DarkBlue, $"Info: {description}");
                    break;  
                case SeverityLevel.Warning:
                    WriteLine(ex, ConsoleColor.DarkYellow, $"Warning: {description}");
                    break;  
                case SeverityLevel.Error:
                    WriteLine(ex, ConsoleColor.Red, $"Error: {description}");
                    break;  
                case SeverityLevel.Critical:
                    WriteLine(ex, ConsoleColor.Magenta, $"Critical: {description}");
                    break;
            }
        }

        private void WriteLine(Exception ex, ConsoleColor color, string text)
        {
            switch(ex)
            {
                case DatabaseException dbex:
                    text = $"[Database - {dbex.DbName}]: " + text;
                    break;
                case FileSystemException fsex:
                    text = $"[FS -]: " + text;
                    break;
                case HttpException httpex:
                    text = $"[HTTP - {httpex.StatusCode} - {httpex.Url}]: " + text;
                    text = HandleHttpError(httpex,text);
                    break;
                default:
                    break;
            }
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }

        private string HandleHttpError(Exception ex, string text)
        {
            //Beauty of c#8  new features
            if(ex is HttpException)
            {
                HttpException httpEx = ex as HttpException;
                return httpEx.StatusCode switch
                {
                    400 => "[NOT FOUND]",
                    500 => "[INTERNAL SERVER ERROR]",
                    _ => text
                };
            }
            else
            {
                return text;
            }

        }
    }
}
