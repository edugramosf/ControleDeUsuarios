using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContatoModel> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("DataSource=app.db;Cache=Shared");
            
    }
}
