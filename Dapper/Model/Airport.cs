using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAppDapper.Model
{
    public class Airport
    {
        public readonly static string INSERT = "INSERT INTO Airport (City, Country, Code, Continent) " +
                           "VALUES (@City, @Country, @Code, @Continent)";
        public readonly static string GETALL = "SELECT Id, City, Country, Code, Continent FROM Airport";

        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public string Continent { get; set; }



        public override string ToString()
        {
            return $"Id: {Id}\nCity: {City}\nCountry: {Country}\nCode: {Code}\nContinent: {Continent}";
        }





    }
}
