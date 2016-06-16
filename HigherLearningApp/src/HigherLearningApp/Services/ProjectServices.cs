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

        /// <summary>
        /// For admin use
        /// Returns all projects (active and inactive)
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAllProjects()
        {
            var projects = _repo.Query<Project>().ToList();
            return projects;
        }

        /// <summary>
        /// Returns all active projects associated with logged in user (requires login)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Project> GetUserProjects(string id)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.Projects).FirstOrDefault();
            user.Projects = user.Projects.Where(p => p.Active == true).ToList();

            var projects = user.Projects.ToList();
            return projects;
        }

        /// <summary>
        /// For all users (does not require login)
        /// Returns all active projects
        /// </summary>
        /// <returns></returns>
        public List<Project> GetActiveProjects()
        {
            var projects = _repo.Query<Project>().Where(p => p.Active == true).ToList();
            return projects;
        }


        public Project GetProject(int id)
        {
            var project = _repo.Query<Project>().Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            project.Views++;
            return project;
        }

        public void SaveProject(Project project, string id)
        {
            if (project.Id == 0)
            {
                var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.Projects).FirstOrDefault();
                user.Projects.Add(project);
                //_repo.SaveChanges();

                project.Active = true;
                project.Votes = 0;
                project.Views = 0;
                project.Time = DateTime.UtcNow;     
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
            projectDelete.Active = false;
            _repo.SaveChanges();
        }
    }
}
