using Microsoft.AspNetCore.Mvc;
using my_books_application.Exceptions;
using my_books_application.Services.PublisherServices;
using my_books_data.DTOs.PublisherDTOs;
using my_books_data.Entities;
using my_books_data.Extensions.PublisherEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        // GET: api/<PublishersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDTO>>> Get()
        {
            return Ok(await publisherService.GetPublishersAsync());
        }

        // GET: api/<PublishersController>/publisher-with-books
        [HttpGet("publisher-with-books")]
        public async Task<ActionResult<IEnumerable<PublisherWithBooksDTO>>> GetPublishersWithBooks() 
        {
            return Ok(await publisherService.GetPublishersWithBooksAsync());
        }

        // GET api/<PublishersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherDTO>> Get(int id)
        {
            var publisher = await publisherService.GetPublisherAsync(id);

            if (publisher is null) return NotFound();

            return Ok(publisher);
        }

        // GET api/<PublishersController>/publisher-with-books/5
        [HttpGet("publisher-with-books/{id}")]
        public async Task<ActionResult<PublisherWithBooksDTO>> GetPublisherWithBooksAsync(int id)
        {
            var publisherWithBooksDto = await publisherService.GetPublisherWithBooksAsync(id);

            if (publisherWithBooksDto is null) return NotFound();

            return Ok(publisherWithBooksDto);
        }

        // POST api/<PublishersController>
        [HttpPost]
        public async Task<ActionResult<PublisherDTO>> Post([FromBody] CreatePublisherDTO publisherDTO)
        {
            try
            {
                var publisher = await publisherService.CreateAsync(publisherDTO);

                return CreatedAtAction(nameof(Get), publisher.AsDto());
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PublishersController>/5
        [HttpPut]
        public async Task<ActionResult<PublisherDTO>> Put([FromBody] UpdatePublisherDTO publisherDTO)
        {
            try
            {
                var publisher = await publisherService.UpdateAsync(publisherDTO);

                return CreatedAtAction(nameof(Get), publisher.AsDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await publisherService.DeleteAsync(id);

                return RedirectToAction(nameof(Get));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
