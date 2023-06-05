using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LicoriceBack.Models;

namespace LicoriceBack.Data
{
    public class LicoriceBackContext : DbContext
    {
        public LicoriceBackContext (DbContextOptions<LicoriceBackContext> options)
            : base(options)
        {
        }

        public DbSet<LicoriceBack.Models.Wall> Walls { get; set; } = default!;

        public DbSet<LicoriceBack.Models.Cube> Cubes { get; set; } = default!;

        public DbSet<LicoriceBack.Models.Card> Cars { get; set; } = default!;
    }
}
