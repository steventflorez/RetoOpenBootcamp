using FacturasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturasApi.Context
{
    public class FacturasApiDBContext : DbContext
    {
        public FacturasApiDBContext(DbContextOptions options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);



        }
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Enterprise> enterprises => Set<Enterprise>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<LineInvoice> LineInvoices => Set<LineInvoice>();

    }
}
