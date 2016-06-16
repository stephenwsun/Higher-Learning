using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HigherLearningApp.Data;
using HigherLearningApp.Models;
using HigherLearningApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private IProjectServices _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(IProjectServices service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/project/getallprojects
        [HttpGet]
        [Route("getallprojects")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAllProjects()
        {
            var projects = _service.GetAllProjects();
            return Ok(projects);
        }

        // GET: api/project/getuserprojects
        [HttpGet]
        [Route("getuserprojects")]
        [Authorize]
        public IActionResult GetUserProjects()
        {
            var userId = _userManager.GetUserId(this.User);
            var projects = _service.GetUserProjects(userId);
            return Ok(projects);
        }

        // GET: api/project/getactiveprojects
        [HttpGet]
        [Route("getactiveprojects")]
        public IActionResult GetActiveProjects()
        {
            var projects = _service.GetActiveProjects();
            return Ok(projects);
        }       

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = _service.GetProject(id);
            return Ok(project);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var userId = _userManager.GetUserId(this.User);
                _service.SaveProject(project, userId);
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
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _service.DeleteProject(id);
                return Ok();
            }           
        }
    }
}
