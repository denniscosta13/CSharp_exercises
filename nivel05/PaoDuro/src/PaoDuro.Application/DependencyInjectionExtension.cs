using Microsoft.Extensions.DependencyInjection;
using PaoDuro.Application.UseCase.Despesas.Register;

namespace PaoDuro.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterDespesaUseCase, RegisterDespesaUseCase>();
    }
}
