using Bogus;
using PaoDuro.Communication.Enums;
using PaoDuro.Communication.Requests;

namespace CommonTestUtility.Requests;

public  class RequestRegisterDespesaJsonBuilder
{
    public static RequestRegisterDespesaJson Build()
    {

        /* 
           var faker = new Faker();
           var request = new RequestRegisterDespesaJson
         {
             Title = faker.Commerce.Product(),
             Description = faker.Commerce.ProductDescription(),
             Date = faker.Date.Past(),
             Amount = faker.Finance.Amount(0, 1000, 2),
             PaymentType = 
         };*/

        return new Faker<RequestRegisterDespesaJson>()
            .RuleFor(req => req.Title, faker => faker.Commerce.ProductName())
            .RuleFor(req => req.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(req => req.Date, faker => faker.Date.Past())
            .RuleFor(req => req.Amount, faker => faker.Finance.Amount(1, 1000, 2))
            .RuleFor(req => req.PaymentType, faker => faker.PickRandom<PaymentType>());

            
    }
}
