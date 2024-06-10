using Microsoft.Extensions.DependencyInjection;
using PaoDuro.Domain.Repositories.Despesas;
using PaoDuro.Infrastructure.DataAccess.Repositories;

namespace PaoDuro.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDespesasRepository, DespesasRepository>();
    }
}
