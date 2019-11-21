using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Exceptions;


namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ///use can change the Exception and that it works just ok
                throw new HttpException("Http Connection error", "http://blablabla", 400);

            }
            catch (Exception err)
            {
                IReporter reporter = new Reporter();
                reporter.Report(err, "Http Error", SeverityLevel.Critical);

            }
            Console.ReadKey();          
        }     
    }
}
