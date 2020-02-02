using System;
using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D2_BookAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PublishersController : ControllerBase
        {
            private readonly IPublisherService _publisherService;

            // Constructor
            public PublishersController(IPublisherService publisherService)
            {
                // TODO: keep a reference to the service so we can use below
                _publisherService = publisherService;
            }

            // TODO: get all publishers
            // GET api/publishers
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_publisherService.GetAll());
            }

            // get specific publisher by id
            // GET api/publishers/:id
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var publisher = _publisherService.Get(id);
                if (publisher == null) return NotFound();
                return Ok(publisher);
            }

            // create a new publisher
            // POST api/publishers
            [HttpPost]
            public IActionResult Post([FromBody] Publisher newPublisher)
            {
                try
                {
                    // add the new publisher
                    _publisherService.Add(newPublisher);
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                    return BadRequest(ModelState);
                }

                // return a 201 Created status. This will also add a "location" header
                // with the URI of the new publisher. E.g., /api/publishers/99, if the new is 99
                return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
            }

            // TODO: update an existing publisher
            // PUT api/publishers/:id
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Publisher updatedPublisher)
            {
                var publisher = _publisherService.Update(updatedPublisher);
                if (publisher == null) return NotFound();
                return Ok(publisher);
            }

            // TODO: delete an existing publisher
            // DELETE api/publishers/:id
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var publisher = _publisherService.Get(id);
                if (publisher == null) return NotFound();
                _publisherService.Remove(publisher);
                return NoContent();
            }
        }
}


