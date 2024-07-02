using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaoDuro.Domain.Repositories;
using PaoDuro.Domain.Repositories.Despesas;
using PaoDuro.Infrastructure.DataAccess;
using PaoDuro.Infrastructure.DataAccess.Repositories;

namespace PaoDuro.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDespesasWriteOnlyRepository, DespesasRepository>();
        services.AddScoped<IDespesasReadOnlyRepository, DespesasRepository>();
        services.AddScoped<IDespesasUpdateOnlyRepository, DespesasRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        //informacoes do servidor que esta o banco de dados
        var connectionString = configuration.GetConnectionString("Connection"); ;
        //versao do servidor que o banco de dados está rodando, obtido atraves da query: SELECT VERSION();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 37));


        services.AddDbContext<PaoDuroDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
