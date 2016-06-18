using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using HigherLearningApp.Models;
using System.Collections.Generic;

namespace HigherLearningApp.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            //// Ensure Stephen (IsAdmin)
            //var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            //if (stephen == null)
            //{
            //    // create user
            //    stephen = new ApplicationUser
            //    {
            //        UserName = "Stephen.Walther@CoderCamps.com",
            //        Email = "Stephen.Walther@CoderCamps.com"
            //    };
            //    await userManager.CreateAsync(stephen, "Secret123!");

            //    // add claims
            //    await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            //}

            // Ensure Stephen Sun (IsAdmin)
            var stephen = await userManager.FindByNameAsync("stephensun.me@gmail.com");
            if (stephen == null)
            {
                stephen = new ApplicationUser
                {
                    UserName = "stephensun.me@gmail.com",
                    Email = "stephensun.me@gmail.com",
                    FirstName = "Stephen",
                    LastName = "Sun",
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            Active = true,
                            Title = "How to Create a To-Do List",
                            Body = "Using a combination of Javascript, HTML, and Bootstrap, we can make a quick To-Do list that looks nice and works well.",
                            Category = "Web Development",
                            Time = DateTime.UtcNow,
                            Votes = 0,
                            Views = 0,

                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Active = true,
                                    Message = "Great guide!",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                },
                                new Comment
                                {
                                    Active = true,
                                    Message = "I followed your tutorial step-by-step, and it worked very well.",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                }
                            },
                            Images = new List<Image>
                            {
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768"
                                }
                            },

                        },
                        new Project
                        {
                            Active = true,
                            Title = "How to Create a Blinking PCB for Valentine's Day",
                            Body = "Valentine's Day is around the corner, so I want to share a cool project consisting of multiple PCBs that you can give to your loved one.",
                            Category = "Embedded Systems",
                            Votes = 0,
                            Views = 0,
                            Time = DateTime.UtcNow,
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Active = true,
                                    Message = "Really interesting guide!",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                },
                                new Comment
                                {
                                    Active = true,
                                    Message = "My girlfriend love the gift, thank you!",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                }
                            },
                            Images = new List<Image>
                            {
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768"
                                }
                            },
                        },
                        new Project
                        {
                            Active = true,
                            Title = "How to Transform your Raspberry Pi into a Media Center",
                            Body = "This is a project that I created with my Raspberry Pi that uses it as a media center.",
                            Category = "Computers",
                            Votes = 0,
                            Views = 0,
                            Time = DateTime.UtcNow,
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Active = true,
                                    Message = "Fantastic project!",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                },
                                new Comment
                                {
                                    Active = true,
                                    Message = "Awesome project",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                }
                            },
                            Images = new List<Image>
                            {
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768"
                                }
                            },
                        },
                        new Project
                        {
                            Active = true,
                            Title = "How to Create an Enclosure for your PCB design",
                            Body = "With a 3D printer, I was able to create a custom PCB enclosure for my PCB.",
                            Category = "3D Printing",
                            Votes = 0,
                            Views = 0,
                            Time = DateTime.UtcNow,
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Active = true,
                                    Message = "Cool!",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                },
                                new Comment
                                {
                                    Active = true,
                                    Message = "Absolutely amazing work.",
                                    Votes = 0,
                                    Time = DateTime.UtcNow
                                }
                            },
                            Images = new List<Image>
                            {
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768",
                                },
                                new Image
                                {
                                    Url = "http://img.lum.dolimg.com/v1/images/Darth-Vader_6bda9114.jpeg?region=0%2C23%2C1400%2C785&width=768"
                                }
                            },
                        },
                    }
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }


        }

    }
}
