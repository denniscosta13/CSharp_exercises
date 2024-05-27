## Anotações

```cs
//url da api em letras minusculas
builder.Services.AddRouting(options => options.LowercaseUrls = true)
```

### Controller
O Controller da classe contem as rotas/endpoint e definição de request e responses de cada endpoint.

#### CRUD comum
- GetAll&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**[GET]**
- GetById&nbsp;&nbsp;**[GET]**
- Register&nbsp;&nbsp;**[POST]**
- Update&nbsp;&nbsp;&nbsp;**[PUT]**
- Delete&nbsp;&nbsp;&nbsp;&nbsp;**[DELETE]**

### Arquitetura

#### API

Exemplo de método HTTP:

```cs
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        var repsonse = new GetByIdUseCase().Execute(id);
        
        return Ok(repsonse);

    }
```

#### Communication

Nessa camada, estão as classes responsáveis pelas `Requests` e `Responses`, agrupadas por pastas de mesmo nome.

Essas classes possuem atributos e seus `getters e setters`:

```cs
//Request
public class RequestPetJson
{
    public string Name {  get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public PetType Type { get; set; }
}


//Response
public class ResponseShortPetJson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
}


```

Nomenclatura padrão: `Response[Classe Return Type]Json.cs`

#### Application

```
Application
|   
└─── UseCases
|   |
|   └─── Pets
|       |
|       └─── Delete
|           |   DeletePetById.cs
|           
|       └─── GetAll
|           |   GetAllPetsUseCase.cs
|           
|       └─── GetById
|           |   GetByIdUseCase.cs
|           
|       └─── Register
|           |   RegisterPetUseCase.cs
|           
|       └─── Update
|           |   UpdatePetUseCase.cs          
```

Cada classe dessa possui um método `Execute()` que pode ou não receber um paramentro e que manipula os dados necessário, seja para alterar ou obter dados de um banco de dados, enviar um e-mail, etc.

Para este exemplo inicial, o método instancia uma classe de Response com os valores fictícios:

```cs
using PetFolio.Communication.Responses;

namespace PetFolio.Application.UseCases.Pets.Get;

public class GetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Hulk",
            Birthday = new DateTime(2015, 12, 25),
            Type = Communication.Enums.PetType.Dog
        };
    }
}
```

Nomenclatura padrão: `[Action][Class]UseCase.cs`