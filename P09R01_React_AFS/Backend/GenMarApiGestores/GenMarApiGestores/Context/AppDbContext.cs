using GenMarApiGestores.Models;
using Microsoft.EntityFrameworkCore;

namespace GenMarApiGestores.Context
{
    public class AppDbContext : DbContext
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { 

        }
        
        //Sirve para modificar y consultar los registros de la tabla
        public DbSet <Gestores_BD> gestores_bd {  get; set; }
    }
}
