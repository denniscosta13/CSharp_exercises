using Microsoft.EntityFrameworkCore;
using PaoDuro.Domain.Entities;

namespace PaoDuro.Infrastructure.DataAccess;

public class PaoDuroDbContext : DbContext
{
    public DbSet<Despesa> Despesas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //informacoes do servidor que esta o banco de dados
        var connectionString = "Server=localhost;Database=paodurodb;Uid=root;Pwd=@senha1";
        //versao do servidor que o banco de dados está rodando, obtido atraves da query: SELECT VERSION();
        var serverVersion = new MySqlServerVersion(new Version(8,0,37));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
