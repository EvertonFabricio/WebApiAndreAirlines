using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace GetAirportEntityFramework.Data
{
    public class GetAirportEntityFrameworkContext : DbContext
    {
        public GetAirportEntityFrameworkContext (DbContextOptions<GetAirportEntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Airport> Airport { get; set; }
    }
}
