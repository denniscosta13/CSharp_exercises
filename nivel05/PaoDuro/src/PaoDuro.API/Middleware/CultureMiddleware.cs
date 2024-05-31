using System.Globalization;

namespace PaoDuro.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // pega uma lista de culturas suportadas pelo dotnet
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList() ;
        
        // extrai do header a localizacao/cultura/idioma que o client deseja
        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();



        //instanciado uma cultura padrão com idioma ingles
        var cultureInfo = new CultureInfo("en");

        // se a cultura veio preenchida na request, sobreescreve a cultura padrão com a requisitada
        // também verifica se a cultura passada é suportada pelo .NET, caso não seja utiliza a default que definimos na var cultureInfo
        if (!string.IsNullOrWhiteSpace(requestedCulture) && supportedLanguages.Exists(lang => lang.Name.Equals(requestedCulture)) )
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        //define a cultura padrão ou requisitada
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        // definida a cultura, o await _next permite e redireciona a API para o endpoint, mantendo a execução do código na sua ordem natural
        await _next(context);
    }
}
