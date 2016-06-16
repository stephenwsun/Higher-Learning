using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Message { get; set; }
        public int Votes { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
