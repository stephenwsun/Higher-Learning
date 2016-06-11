using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Votes { get; set; }
        public DateTime Time { get; set; }
    }
}
