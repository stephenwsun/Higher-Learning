using HigherLearningApp.Models;
using HigherLearningApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Services
{
    public class ImageServices : IImageServices
    {
        private IGenericRepository _repo;

        public ImageServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void SaveImage(int id, Image image)
        {
            var project = _repo.Query<Project>().Where(p => p.Id == id).Include(p => p.Images).FirstOrDefault();
            project.Images.Add(image);
            _repo.SaveChanges();
        }
    }
}
