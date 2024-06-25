using AutoMapper;
using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;
using PaoDuro.Domain.Entities;

namespace PaoDuro.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterDespesaJson, Despesa>();
    }

    private void EntityToResponse()
    {
        CreateMap<Despesa, ResponseRegisterDespesaJson>();
        CreateMap<Despesa, ResponseShortDespesaJson>();
    }
}
