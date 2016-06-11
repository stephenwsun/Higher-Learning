using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HigherLearningApp.Data;
using HigherLearningApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private ApplicationDbContext _db;

        public CommentController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(int id, [FromBody]Comment comment)
        {
            var project = _db.Projects.Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            project.Comments.Add(comment);
            _db.SaveChanges();

            return Ok();
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
