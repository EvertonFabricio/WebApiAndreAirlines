using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetAirportEntityFramework.Data;
using Model;

namespace GetAirportEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly GetAirportEntityFrameworkContext _context;

        public AirportsController(GetAirportEntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: api/Airports

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirport()
        {
            return await _context.Airport.ToListAsync();
        }

       
    }
}
