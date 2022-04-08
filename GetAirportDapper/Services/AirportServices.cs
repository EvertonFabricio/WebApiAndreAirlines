using System.Collections.Generic;
using GetAirportDapper.Repository;
using Model;

namespace GetAirportDapper.Services
{
   
        public class AirportServices //Classe responsável pelos serviços
        {

            private IAirportRepository _airpotyDateReposity; //Criando um campo com referencia a Interface IAirpotyDateReposity

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
