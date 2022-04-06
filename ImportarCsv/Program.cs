using System;
using System.IO;
using ProjAppDapper.Model;
using ProjAppDapper.Service;

namespace ProjAppDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    StreamReader lerArquivo = new StreamReader(@"C:\Users\Everton Fabricio\Desktop\WebApiAndreAirlines\WebApiAndreAirlines\bin\Debug\net5.0\Data\Dados.csv");
                    
                    string line;
                    do
                    {
                        line = lerArquivo.ReadLine();
                        if (line != null)
                        {
                            var values = line.Split(';');

                            Airport airport = new Airport()
                            {
                                City = values[0],
                                Country = values[1],
                                Code = values[2],
                                Continent = values[3]
                            };
                            new AirportService().Add(airport);
                        }
                    } while (line != null);
                    lerArquivo.Close();
                }
                catch (Exception erro)
                {
                    Console.WriteLine("Erro na comunicação:>>> " + erro);
                }
            }
        }
    }
}
