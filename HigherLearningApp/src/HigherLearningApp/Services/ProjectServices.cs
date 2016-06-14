using HigherLearningApp.Models;
using HigherLearningApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Services
{
    public class ProjectServices :IProjectServices
    {
        private IGenericRepository _repo;

        public ProjectServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Project> GetProjects()
        {
            var projects = _repo.Query<Project>().ToList();
            return projects;
        }

        public Project GetProject(int id)
        {
            var project = _repo.Query<Project>().Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            project.Views++;
            return project;
        }

        public void SaveProject(Project project)
        {
            if(project.Id == 0)
            {
                _repo.Add(project);
            }
            else
            {
                var projectEdit = _repo.Query<Project>().FirstOrDefault(p => p.Id == project.Id);
                projectEdit.Title = project.Title;
                projectEdit.Body = project.Body;
                projectEdit.Category = project.Category;
                projectEdit.Votes = project.Votes;
                projectEdit.Views = project.Views;
                projectEdit.Time = DateTime.UtcNow;
                _repo.SaveChanges();
            }
        }

        public void DeleteProject(int id)
        {
            var projectDelete = _repo.Query<Project>().Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            _repo.Delete(projectDelete);
        }
    }
}
