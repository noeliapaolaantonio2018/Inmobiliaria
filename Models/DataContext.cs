using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Propietarios> Propietarios { get; set; }
        public DbSet<Inquilinos> Inquilinos { get; set; }
        public DbSet<Inmuebles> Inmuebles { get; set; }

        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Pagos> Pagos { get; set; }


        public DbSet<Personas> Personas { get; set; }
        public DbSet<Pasatiempo> Pasatiempos { get; set; }
        public DbSet<PersonaPasatiempo> PersonaPasatiempos { get; set; }

        
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
