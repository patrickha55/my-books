using Microsoft.AspNetCore.Mvc;
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
            var publisherDtos = (await publisherService.GetPublishersAsync()).Select(p => p.AsDto()).ToList();
            return Ok(publisherDtos);
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
            Publisher publisher = new() { Name = publisherDTO.Name };

            await publisherService.CreateAsync(publisher);

            return CreatedAtAction(nameof(Get), new { Id = publisher.Id }, publisher);
        }

        // PUT api/<PublishersController>/5
        [HttpPut]
        public async Task<ActionResult<PublisherDTO>> Put([FromBody] UpdatePublisherDTO publisherDTO)
        {
            var publisher = await publisherService.GetPublisherAsync(publisherDTO.Id);

            if (publisher is null) return NotFound();

            publisher.Name = publisherDTO.Name;

            await publisherService.UpdateAsync(publisher);

            return CreatedAtAction(nameof(Get), new { Id = publisher.Id }, publisher);
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var publisher = await publisherService.GetPublisherAsync(id);

            if (publisher is null) return NotFound();

            await publisherService.DeleteAsync(publisher);

            return RedirectToAction(nameof(Get));
        }
    }
}
