using BoutiqueFarcesEtAttrapes.Models;
using Microsoft.EntityFrameworkCore;

namespace BoutiqueFarcesEtAttrapes
{
    public class BoutiqueFarcesEtAttrapesDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<CommandRow> CommandRows { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public BoutiqueFarcesEtAttrapesDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommandRow>().HasKey(x => new { x.ProductId, x.CommandId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
