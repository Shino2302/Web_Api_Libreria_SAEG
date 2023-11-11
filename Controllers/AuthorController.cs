using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_SAEG.Data.Services;
using Libreria_SAEG.Data.ViewModel;

namespace Libreria_SAEG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorServices;
        
        public AuthorController(AuthorService authorServices) 
        {
            _authorServices = authorServices;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorServices.AddAuthor(author);
            return Ok();
        }
        /*
        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorServices.GetAllAuthors();
            return Ok(allAuthors);
        }
        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorServices.GetAuthorById(id);
            return Ok(author);
        }*/
        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorServices.GetAuthorWithBooks(id);
            return Ok(response); 
        }
    }
}
