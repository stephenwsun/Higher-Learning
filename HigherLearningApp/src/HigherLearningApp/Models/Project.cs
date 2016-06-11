using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
        public DateTime Time { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //public ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
