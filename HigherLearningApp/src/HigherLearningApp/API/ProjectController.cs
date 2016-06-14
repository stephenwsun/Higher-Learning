using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HigherLearningApp.Data;
using HigherLearningApp.Models;
using HigherLearningApp.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private IProjectServices _repo;

        public ProjectController(IProjectServices repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var projects = _repo.GetProjects();
            return Ok(projects);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = _repo.GetProject(id);
            return Ok(project);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _repo.SaveProject(project);
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
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _repo.DeleteProject(id);
                return Ok();
            }           
        }
    }
}
