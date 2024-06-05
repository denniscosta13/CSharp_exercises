using CommonTestUtility.Requests;
using FluentAssertions;
using PaoDuro.Application.UseCase.Despesas.Register;
using PaoDuro.Communication.Enums;
using PaoDuro.Exception;

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
        result.IsValid.Should().BeTrue();

    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("        ")]
    public void Error_Title_Empty(string title)
    {
        //Arrange
        var validator = new RegisterDespesaValidator();
        var request = RequestRegisterDespesaJsonBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITILE_REQUIRED));
    }


    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new RegisterDespesaValidator();
        var request = RequestRegisterDespesaJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.FUTURE_EXPENSES));
    }

    [Fact]
    public void Error_PaymentType_Invalid()
    {
        //Arrange
        var validator = new RegisterDespesaValidator();
        var request = RequestRegisterDespesaJsonBuilder.Build();
        request.PaymentType = (PaymentType)10;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PAYMENT_TYPE));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new RegisterDespesaValidator();
        var request = RequestRegisterDespesaJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }
}
