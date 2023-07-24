using Microsoft.EntityFrameworkCore;
using FretesWebApplication.Models;

namespace FretesWebApplication.Data
{
    public class FretesWebApplicationContext : DbContext
    {
        public FretesWebApplicationContext(DbContextOptions<FretesWebApplicationContext> options) : base(options)
        {
        }

        public DbSet<FretesWebApplication.Models.Veiculo> Veiculo { get; set; }

        public DbSet<FretesWebApplication.Models.Produto>? Produto { get; set; }

        public DbSet<FretesWebApplication.Models.Frete>? Frete { get; set; }

        public DbSet<FretesWebApplication.Models.Usuario>? Usuario { get; set; }
    }
}
