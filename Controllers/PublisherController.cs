using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_SAEG.Data.Services;
using Libreria_SAEG.Data.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using Libreria_SAEG.Excepciones;

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
            try
            {
                var newPublisher = _publisherServices.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);

            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la editora: {ex.PublisherName}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 

        }
        [HttpGet("get-publisher-by-id/")]
        public IActionResult GetPublisherById(int id) 
        {
            var _response = _publisherServices.GetPublisherById(id);
            return Ok(_response);
        }
        [HttpGet("get-publisher-with-books-and-authors-by-id/{id}")]
        public IActionResult GetPublisherWithBooksAndAuthors(int id)
        {
            var _response = _publisherServices.GetPublisherWithBooksAndAuthors(id);
            if(_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("delete-publisher-by-is/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherServices.DeletePublisherById(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //finally
            //{
            //    string stopHere = "";
            //}
        }
    }
}
