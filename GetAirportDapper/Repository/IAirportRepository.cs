using System.Collections.Generic;
using Model;

namespace GetAirportDapper.Repository
{
    public interface IAirportRepository
    {
        bool Add(Airport airport);
        List<Airport> GetAll(); 
       
    }
}
