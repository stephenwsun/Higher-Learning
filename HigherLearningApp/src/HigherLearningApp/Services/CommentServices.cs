using HigherLearningApp.Models;
using HigherLearningApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherLearningApp.Services
{
    public class CommentServices : ICommentServices
    {
        private IGenericRepository _repo;

        public CommentServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void SaveComment(int id, Comment comment)
        {
            var project = _repo.Query<Project>().Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
            comment.Active = true;
            comment.Votes = 0;
            comment.Time = DateTime.UtcNow;
            project.Comments.Add(comment);
            _repo.SaveChanges();
        }
    }
}
