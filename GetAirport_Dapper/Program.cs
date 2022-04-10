using System;
using ImportarCsv.Service;

namespace GetAirport_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio da consulta no Banco de Dados");
            var inicio = DateTime.Now;
            Console.WriteLine(inicio.ToString("H:mm:ss:fff"));
            for (int i = 0; i <= 100; i++)
            {
                foreach (var item in new AirportService().GetAll())
                {
                    //Console.WriteLine(item);
                }
            }
            Console.WriteLine("\nFim da consulta no Banco de Dados");
            var fim = DateTime.Now;
            Console.WriteLine(fim.ToString("H:mm:ss:fff"));
            var dif = fim - inicio;
            Console.Write("\nTempo decorrido: ");
            Console.WriteLine(dif.ToString("ss").Trim('0') + "," + dif.ToString("fff") + "segundos");
        }
    }
}
