using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using ImportarCsv.Config;
using Model;

namespace GetAirportDapper.Repository
{
    public class AirportRepository : IAirportRepository
    {
        private static string _conection; 

        public AirportRepository() 
        {
            _conection = DataBaseConfiguration.Get(); 
        }

        public bool Add(Airport airport) 
        {
            bool status = false; 

            using (var dataBase = new SqlConnection(_conection))
            {
                dataBase.Open(); 
                dataBase.Execute(Airport.INSERT, airport);
                status = true; 
            }
            return status; 
        }

        public List<Airport> GetAll() 
        {
            using (var dataBase = new SqlConnection(_conection))
            {
                dataBase.Open();
                var airport = dataBase.Query<Airport>(Airport.GETALL); 
                return (List<Airport>)airport; 
            }
        }

       
    }
}
