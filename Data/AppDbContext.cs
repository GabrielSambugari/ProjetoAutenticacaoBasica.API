using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacaoBasica.API.Models;

namespace ProjetoAutenticacaoBasica.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Codigo { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<Passagem> Passagens { get; set; }



    }
}
