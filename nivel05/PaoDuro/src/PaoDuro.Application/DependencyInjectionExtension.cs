﻿using Microsoft.Extensions.DependencyInjection;
using PaoDuro.Application.AutoMapper;
using PaoDuro.Application.UseCase.Despesas.GetAll;
using PaoDuro.Application.UseCase.Despesas.Register;

namespace PaoDuro.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterDespesaUseCase, RegisterDespesaUseCase>();
        services.AddScoped<IGetAllDespesasUseCase, GetAllDespesasUseCase>();
    }
}