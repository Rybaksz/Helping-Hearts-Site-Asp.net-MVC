using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRABALHOFINALDOPI.Models;

namespace TRABALHOFINALDOPI.Data
{
    public class TRABALHOFINALDOPIContext : DbContext
    {
        public TRABALHOFINALDOPIContext (DbContextOptions<TRABALHOFINALDOPIContext> options)
            : base(options)
        {
        }

        public DbSet<TRABALHOFINALDOPI.Models.DoarOuReceber> DoarOuReceber { get; set; } = default!;

        public DbSet<TRABALHOFINALDOPI.Models.Pedido>? Pedido { get; set; }

        public DbSet<TRABALHOFINALDOPI.Models.Ong>? Ong { get; set; }
    }
}
