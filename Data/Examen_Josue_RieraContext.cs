using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examen_Josue_Riera.Models;

namespace Examen_Josue_Riera.Data
{
    public class Examen_Josue_RieraContext : DbContext
    {
        public Examen_Josue_RieraContext (DbContextOptions<Examen_Josue_RieraContext> options)
            : base(options)
        {
        }

        public DbSet<Examen_Josue_Riera.Models.Celular> Celular { get; set; } = default!;
        public DbSet<JRiera> JRiera { get; set; } = default!;
    }
}
