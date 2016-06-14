using System.Collections.Generic;
using HigherLearningApp.Models;

namespace HigherLearningApp.Services
{
    public interface IProjectServices
    {
        void DeleteProject(int id);
        List<Project> GetProjects();
        void SaveProject(Project project);
        Project GetProject(int id);
    }
}