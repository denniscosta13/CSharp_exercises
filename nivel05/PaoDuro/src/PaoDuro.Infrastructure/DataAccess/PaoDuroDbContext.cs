using Microsoft.EntityFrameworkCore;
using PaoDuro.Domain.Entities;

namespace PaoDuro.Infrastructure.DataAccess;

internal class PaoDuroDbContext : DbContext
{
    public PaoDuroDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Despesa> Despesas { get; set; }

}
