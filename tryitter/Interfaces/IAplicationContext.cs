using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IAplicationContext
    {
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public int SaveChanges();
    }
}
