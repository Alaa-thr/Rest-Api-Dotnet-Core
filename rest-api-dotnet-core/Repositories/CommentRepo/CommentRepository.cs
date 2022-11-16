using Microsoft.EntityFrameworkCore;
using rest_api_dotnet_core.Data;
using rest_api_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace rest_api_dotnet_core.Repositories.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApiDbContext apiDbContext;
        public CommentRepository(ApiDbContext apiDbContext)//dependency injection means we don't use keyword 'new' to initializ the instance apiDbContext, but we inject 
        /* If we do apiDbContext = new ApiDbContext() => we are coupling this class to ApiDbContext*/
        {
            this.apiDbContext = apiDbContext;
        }
        public async Task<Comment> Create(Comment comment)
        {
            var result = await apiDbContext.Comments.AddAsync(comment);
            await apiDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id)
        {
            var result = await FindById(id);
            apiDbContext.Comments.Remove(result);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> FindAll()// Task=> needed to be in async method, it represents the async operation
        //Task<IEnumerable<T>> => return all data once its collected and ready to send to the caller
        //IAsyncEnumerable => send to the caller the data as it ready without waiting to collect all the data
        //IEnumerable is read only of collection, it provides an interface for getting the next item one-by-one only
        //List is read,add,delete,...
        {
            return await apiDbContext.Comments.ToListAsync();
        }

        public async Task<Comment> FindById(Guid id)
        {
            return await apiDbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> Update(Guid id, Comment comment)
        {
            var result = await FindById(id);
            if (result != null)
            {
                result.Text = comment.Text;
                await apiDbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
