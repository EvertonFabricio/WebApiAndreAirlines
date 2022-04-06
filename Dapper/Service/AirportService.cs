using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjAppDapper.Model;
using ProjAppDapper.Repository;

namespace ProjAppDapper.Service
{
    public class AirportService
    {
        private IAirportRepository _airportRepository;

        public AirportService()
        {
            _airportRepository = new AirportRepository();
        }

        public bool Add(Airport airport)
        {
            return _airportRepository.Add(airport);
        }

        public List<Airport> GetAll()
        {
            return _airportRepository.GetAll();
        }

    }
}
