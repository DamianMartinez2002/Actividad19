using Actividad18.Shared.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Actividad18.Server.Contexto
{
    public class CotextoTienda: DbContext
    {
        public CotextoTienda(DbContextOptions<CotextoTienda> options) : base(options)
        {

        }
        public DbSet<Clientes> Clientes { get; set;}
        public DbSet<Productos> Productos { get; set;}
        public DbSet<Ventas> Ventas { get; set;}
    }
}
