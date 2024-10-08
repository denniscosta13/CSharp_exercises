﻿using Microsoft.Extensions.DependencyInjection;
using PaoDuro.Application.AutoMapper;
using PaoDuro.Application.UseCase.Despesas.Delete;
using PaoDuro.Application.UseCase.Despesas.GetAll;
using PaoDuro.Application.UseCase.Despesas.GetById;
using PaoDuro.Application.UseCase.Despesas.Register;
using PaoDuro.Application.UseCase.Despesas.Reports.Excel;
using PaoDuro.Application.UseCase.Despesas.Reports.Pdf;
using PaoDuro.Application.UseCase.Despesas.Update;

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
        services.AddScoped<IGetDespesaByIdUseCase, GetDespesaByIdUseCase>();
        services.AddScoped<IDeleteDespesaUseCase, DeleteDespesaUseCase>();
        services.AddScoped<IUpdateDespesaUseCase, UpdateDespesaUseCase>();
        services.AddScoped<IGenerateDespesasReportExcelUseCase, GenerateDespesasReportExcelUseCase>();
        services.AddScoped<IGenerateDespesaReportPdfUseCase, GenerateDespesaReportPdfUseCase>();
    }
}