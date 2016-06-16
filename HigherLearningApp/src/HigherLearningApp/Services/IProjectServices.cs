using System.Collections.Generic;
using HigherLearningApp.Models;

namespace HigherLearningApp.Services
{
    public interface IProjectServices
    {
        void DeleteProject(int id);
        List<Project> GetAllProjects();
        List<Project> GetUserProjects(string id);
        List<Project> GetActiveProjects();
        void SaveProject(Project project, string id);
        Project GetProject(int id);
    }
}