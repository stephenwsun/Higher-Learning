using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HigherLearningApp.Models;

namespace HigherLearningApp.Data
{
    public class ProjectSampleData
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            if (!db.Projects.Any())
            {
                var projects = new Project[]
                {
                    new Project
                    {
                        Title = "How to Create a To-Do List",
                        Body = "Using a combination of Javascript, HTML, and Bootstrap, we can make a quick To-Do list that looks nice and works well.",
                        Category = "Web Development",
                        Time = DateTime.UtcNow,
                        Votes = 0,
                        Views = 0,
                        
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Great guide!", Votes = 0, Time = DateTime.UtcNow },
                            new Comment { Message = "I followed your tutorial step-by-step, and it worked very well.", Votes = 0, Time = DateTime.UtcNow  }
                        }

                    },
                    new Project
                    {
                        Title = "How to Create a Blinking PCB for Valentine's Day",
                        Body = "Valentine's Day is around the corner, so I want to share a cool project consisting of multiple PCBs that you can give to your loved one.",
                        Category = "Embedded Systems",
                        Votes = 0,
                        Views = 0,
                        Time = DateTime.UtcNow,
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Really interesting guide!", Votes = 0, Time = DateTime.UtcNow },
                            new Comment { Message = "My girlfriend love the gift, thank you!", Votes = 0, Time = DateTime.UtcNow }
                        }

                    },
                    new Project
                    {
                        Title = "How to Transform your Raspberry Pi into a Media Center",
                        Body = "This is a project that I created with my Raspberry Pi that uses it as a media center.",
                        Category = "Computers",
                        Votes = 0,
                        Views = 0,
                        Time = DateTime.UtcNow,
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Fantastic project!", Votes = 0, Time = DateTime.UtcNow },
                            new Comment { Message = "Awesome project", Votes = 0, Time = DateTime.UtcNow }
                        }

                    },
                    new Project
                    {
                        Title = "How to Create an Enclosure for your PCB design",
                        Body = "With a 3D printer, I was able to create a custom PCB enclosure for my PCB.",
                        Category = "3D Printing",
                        Votes = 0,
                        Views = 0,
                        Time = DateTime.UtcNow,
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Cool!", Votes = 0, Time = DateTime.UtcNow },
                            new Comment { Message = "Absolutely amazing work.", Votes = 0, Time = DateTime.UtcNow }
                        }
                    },
                };
                db.Projects.AddRange(projects);
                db.SaveChanges();
            }
        }
    }
}
