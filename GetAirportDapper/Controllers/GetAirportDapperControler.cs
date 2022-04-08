using System.Collections.Generic;
//using GetAirport_Dapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace GetAirportDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAirportDapperControler : ControllerBase
    {
        //[Route("api/[controller]")]
        //[ApiController]
        //public class DapperController : ControllerBase
        //{
        //    private readonly AirportServices _airportService;

        //    public DapperController(AirportServices airportService)
        //    {
        //        _airportService = airportService;
        //    }

        //    [HttpGet]
        //    public ActionResult<List<Airport>> Get() =>
        //        _airportService.GetAll();

        //}
    }
}
