using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HigherLearningApp.Services;
using Microsoft.AspNetCore.Identity;
using HigherLearningApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HigherLearningApp.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private IImageServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(IImageServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("{id}")]
        [Authorize]
        public IActionResult Post(int id, [FromBody]Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                image.Id = 0;
                _service.SaveImage(id, image);
                return Ok();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
