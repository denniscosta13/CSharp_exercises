using Microsoft.AspNetCore.Mvc;
using RocketLibrary.Communication.Request;
using RocketLibrary.Communication.Response;

namespace RocketLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var booksList = new List<Book>();
            booksList.Add(
                new Book
                {
                    Id = 1,
                    Author = "Jose",
                    Gender = "Mistério",
                    Price = 10,
                    Storage = 25,
                    Title = "My Mystery Book",
                }
                );

            booksList.Add(
                new Book
                {
                    Id= 2,
                    Author = "Dennis",
                    Gender = "Ficção",
                    Price = 22,
                    Storage = 30,
                    Title = "Time Travelling",
                }
                );

            return Ok(booksList);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterBookJson) ,StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RequestRegisterBookJson request) 
        {
            var response = new ResponseRegisterBookJson()
            {
                Id = request.Id,
                Title = request.Title
            };

            return Created(string.Empty, response); 
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update([FromBody] RequestUpdateBookJson request)
        {
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete() { return NoContent(); }

    }
}
