using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using HigherLearningApp.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherLearningApp.API
{
    [Route("api/[controller]")]
    public class SecretsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SecretsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<string> Get()
        {
            var user = this.User;
            var userId = _userManager.GetUserId(user);
            return new string[] { "The Cake is a Lie!", "Darth Vader is Luke's Father.", userId };
        }


    }
}
