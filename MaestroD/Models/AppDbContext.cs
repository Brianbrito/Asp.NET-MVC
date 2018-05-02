using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaestroD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }
    
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Jugador> Jugadors { get; set; }

    }
}