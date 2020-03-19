using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class RideBikePlanifierContext : DbContext
    {
        public RideBikePlanifierContext(DbContextOptions<RideBikePlanifierContext> options) : base(options)
        {
        }

        public DbSet<Usuario> usuarios { get; set; }
    }
}
