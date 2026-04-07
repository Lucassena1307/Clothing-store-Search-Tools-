
using Microsoft.EntityFrameworkCore;
using LojaOstentacaoAPI.Models;

namespace LojaOstentacaoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}