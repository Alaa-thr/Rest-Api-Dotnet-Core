using rest_api_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rest_api_dotnet_core.Repositories.CommentRepo
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> FindAll();
        Task<Comment> Create(Comment comment);
        Task<Comment> FindById(Guid id);
        Task<Comment> Update(Guid id, Comment comment);
        Task Delete(Guid id);// Task without <> it is the same as void, but we need it cuz the fct will be async
    }
}
