using AlphaApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlphaApi.Controllers
{

    public class DeviceController : AlphaApiBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            /*Nao podemos instanciar classes abstratas*/
            /*var device = new Device();*/
/*
            var book2 = new Notebook();
            var model = book2.GetModel();

            return Ok(model);*/

            var key = GetCustomKey();

            return Ok(key);
        }
    }
}
