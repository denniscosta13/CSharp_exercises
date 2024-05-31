using CommonTestUtility.Requests;
using PaoDuro.Application.UseCase.Despesas.Register;
using PaoDuro.Communication.Requests;

namespace Validators.Tests.Despesas.Register;

public class RegisterDespesaValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterDespesaValidator();
        var request = RequestRegisterDespesaJsonBuilder.Build();


        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);

    }
}
