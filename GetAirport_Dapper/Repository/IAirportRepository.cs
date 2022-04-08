using System.Collections.Generic;
using Model;

namespace GetAirport_Dapper.Repository
{
    public interface IAirportRepository
    {
        bool Add(Airport airport);
        List<Airport> GetAll(); 
       
    }
}
