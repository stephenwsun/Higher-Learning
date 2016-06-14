using HigherLearningApp.Models;

namespace HigherLearningApp.Services
{
    public interface ICommentServices
    {
        void SaveComment(int id, Comment comment);
    }
}