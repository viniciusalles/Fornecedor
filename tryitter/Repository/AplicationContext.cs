using Microsoft.EntityFrameworkCore;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Database
{
    public class AplicationContext : DbContext, IAplicationContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) {}
        public DbSet<Fornecedor> Fornecedor { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Server=localhost\SQLEXPRESS02;Database=master;Trusted_Connection=True;


                var connectionString = "Server=DESKTOP-B1LOQ5E;Database=sql_server_db; Integrated Security=True;TrustServerCertificate=True; ";

                if (connectionString is null )
                {
                    throw new InvalidOperationException("Connection string not found");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        
    }
}
