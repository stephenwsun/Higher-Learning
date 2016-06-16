using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HigherLearningApp.Data;
using HigherLearningApp.Models;
using Microsoft.EntityFrameworkCore;
using HigherLearningApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private ICommentServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ICommentServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            //var userId = _userManager.GetUserId(this.User);
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
        public IActionResult Post(int id, [FromBody]Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var userId = _userManager.GetUserId(this.User);
                comment.UserId = userId;

                _service.SaveComment(id, comment);
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
