using HigherLearningApp.Models;

namespace HigherLearningApp.Services
{
    public interface IImageServices
    {
        void SaveImage(int id, Image image);
    }
}