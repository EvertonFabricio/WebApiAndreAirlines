using System;
using ImportarCsv.Service;

namespace GetAirport_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("\n");
            for (int i = 0; i <= 100; i++)
            {
                foreach (var item in new AirportService().GetAll())
                {
                    //Console.WriteLine(item);
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine(DateTime.Now);
        }
    }
}
