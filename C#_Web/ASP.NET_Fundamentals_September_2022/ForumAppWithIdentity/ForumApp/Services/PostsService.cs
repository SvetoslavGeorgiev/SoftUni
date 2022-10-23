namespace ForumApp.Services
{
    using ForumApp.Contracts;
    using ForumApp.Data;
    using ForumApp.Data.Entities;
    using ForumApp.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PostsService : IPostsService
    {
        private readonly ForumAppDbContext dbContext;

        public PostsService(ForumAppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task AddAsync(PostViewModel model, string userId)
        {
            var post = new Post()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content
            };


            var user = await dbContext
                .Users
                .Where(u => u.Id == userId).
                Include(u => u.UsersPosts)
                .FirstOrDefaultAsync();

            //var user = await dbContext.Users.FirstAsync(u => u.Id == userId);

            user.UsersPosts.Add(new UserPost
            {
                PostId = post.Id,
                UserId = user.Id,
                Post = post,
                User = user

            });

            await dbContext.Posts.AddAsync(post);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = dbContext.Posts.FindAsync(id).Result;
            post.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(PostViewModel model)
        {
            var post = await dbContext
                    .Posts.FindAsync(model.Id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetAllAsync(string userId)
        {

            var user = await dbContext
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersPosts)
                .ThenInclude(up => up.Post)
                .FirstAsync();


            var model = user
                .UsersPosts
                .Where(up => up.Post.IsDeleted == false)
                .Select(u => new PostViewModel
                {
                    Id = u.Post.Id,
                    Title = u.Post.Title,
                    Content = u.Post.Content
                })
                .ToList();
                

            //var model = await dbContext
            //    .Posts
            //    .Where(p => p.IsDeleted == false)
            //    .Select(p => new PostViewModel
            //    {
            //        Id = p.Id,
            //        Title = p.Title,
            //        Content = p.Content
            //    })
            //    .ToListAsync();

            return model;

        }

        public async Task<PostViewModel> GetModelForEditAsync(int id)
        {
            var post = await dbContext
                .Posts
                .Where(p => p.Id == id)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).FirstOrDefaultAsync();

            return post;
        }



    }
}
