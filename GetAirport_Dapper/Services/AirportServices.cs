using System.Collections.Generic;
using GetAirport_Dapper.Repository;
using Model;

namespace GetAirport_Dapper.Services
{
   
        public class AirportServices 
        {

            private IAirportRepository _airpotyDateReposity; 

            public AirportServices(IAirportRepository airpotyDateReposity)
            {
                _airpotyDateReposity = airpotyDateReposity;
            }

            public bool Add(Airport newAirport) =>
                _airpotyDateReposity.Add(newAirport);

            public List<Airport> GetAll() =>
                _airpotyDateReposity.GetAll();
        }
    
}
