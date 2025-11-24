using clienteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace clienteAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
