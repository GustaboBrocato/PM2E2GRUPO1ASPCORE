using Microsoft.EntityFrameworkCore;
using PM2E2GRUPO1ASPCORE.Models;

namespace PM2E2GRUPO1ASPCORE.Data
{
    //Clase que representa la base de datos
    public class SitiosDB : DbContext
    {
        //Constructor que recibe DbContextOptions para injectar la cadena de conexion
        public SitiosDB(DbContextOptions<SitiosDB> options) : base(options)
        {
            
        }

        //Representacion de la tabla
        public DbSet<Sitio> Sitios => Set<Sitio>();
    }
}
