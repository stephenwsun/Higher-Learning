using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HigherLearningApp.Data;
using HigherLearningApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var projects = _db.Projects.ToList();
            return Ok(projects);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = _db.Projects.Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            project.Views++;
            _db.SaveChanges();
            return Ok(project);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Project project)
        {
            if(project.Id == 0)
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
            }
            else
            {
                var projectEdit = _db.Projects.FirstOrDefault(p => p.Id == project.Id);
                projectEdit.Title = project.Title;
                projectEdit.Body = project.Body;
                projectEdit.Category = project.Category;
                projectEdit.Votes = project.Votes;
                projectEdit.Views = project.Views;
                projectEdit.Time = DateTime.UtcNow;
                _db.SaveChanges();
            }

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _db.Projects.Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            _db.Projects.Remove(project);
            _db.SaveChanges();
            return Ok();
        }
    }
}
