using apiAutenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace apiAutenticacao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
