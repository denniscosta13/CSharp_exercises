using AutoMapper;
using PaoDuro.Communication.Responses;
using PaoDuro.Domain.Repositories.Despesas;

namespace PaoDuro.Application.UseCase.Despesas.GetAll
{
    public class GetAllDespesasUseCase : IGetAllDespesasUseCase
    {
        private readonly IDespesasRepository _repository;
        private readonly IMapper _mapper;
        public GetAllDespesasUseCase(IDespesasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDespesasJson> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseDespesasJson
            {
                Despesas = _mapper.Map<List<ResponseShortDespesaJson>>(result)
            };
        }
    }
}
