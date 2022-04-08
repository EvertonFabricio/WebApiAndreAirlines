using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using ImportarCsv.Config;
using Model;

namespace GetAirport_Dapper.Repository
{
        public class AirportRepository : IAirportRepository
        {
            private string _conn;

            public AirportRepository()
            {
                _conn = DataBaseConfiguration.Get();
            }

            public bool Add(Airport airport)
            {
                bool status = false;

                using (var db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute(Airport.INSERT, airport);
                    status = true;
                }
                return status;
            }

            public List<Airport> GetAll()
            {
                using (var db = new SqlConnection(_conn))
                {
                    db.Open();
                    var airports = db.Query<Airport>(Airport.GETALL);
                    return (List<Airport>)airports;
                }
            }
        }

    
}
