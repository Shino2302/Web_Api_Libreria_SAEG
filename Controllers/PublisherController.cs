using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_SAEG.Data.Services;
using Libreria_SAEG.Data.ViewModel;

namespace Libreria_SAEG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisherServices;
        
        public PublisherController(PublisherService publisherServices) 
        {
            _publisherServices = publisherServices;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }
        [HttpGet("get-publisher-with-books-and-authors-by-id/{id}")]
        public IActionResult GetPublisherWithBooksAndAuthors(int id)
        {
            var response = _publisherServices.GetPublisherWithBooksAndAuthors(id);
            return Ok(response);
        }
    }
}
