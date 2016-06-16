using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
        public DateTime Time { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
