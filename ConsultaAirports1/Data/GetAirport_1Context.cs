using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GetAirport_1.Model;

namespace GetAirport_1.Data
{
    public class GetAirport_1Context : DbContext
    {
        public GetAirport_1Context (DbContextOptions<GetAirport_1Context> options)
            : base(options)
        {
        }

        public DbSet<GetAirport_1.Model.Airport> Airport { get; set; }
    }
}
