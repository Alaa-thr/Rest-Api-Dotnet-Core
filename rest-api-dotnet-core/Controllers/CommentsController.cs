using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_api_dotnet_core.Models;
using rest_api_dotnet_core.Repositories.CommentRepo;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace rest_api_dotnet_core.Controllers
{
    [ApiController]// to say this is a controller (to use httpGet, post ...)
    [Route("api/[controller]")]// system will replace [controler] with the name of controller 'Comments'
    public class CommentsController : ControllerBase //there's ControllerBase and Controller => ControllerBase is used for Rest Api, Controller is used for MVC Web App
    {
        private readonly ICommentRepository commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        //If we want to use a mongodb config (code to add, update ... the data ) we dont have to change the class CommentRepository, but we will create new one that has the code configured according mongodb and then in startup we change <ICommentRepository, ComentRepositoryMonoDB>
        {
            this.commentRepository = commentRepository;
        }

        [HttpGet]// url => api/comments
        public async Task<ActionResult> FindAll()
        {// this fct returns a list of Comments with code status = 200
            try
            {
                return Ok(await commentRepository.FindAll()); // Ok() is a fct from ControllerBase where it returns a 200 code status
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }

        [HttpGet("{id:Guid}")]   // url=> api/comments/id     
        public async Task<ActionResult<Comment>> FindById(Guid id)
        {
            try
            {
                var result = await commentRepository.FindById(id);
                if (result == null) return NotFound($"The comment with ID {id} not Found");
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Error while retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Create(Comment comment)
        {
            try
            {
                var result = await commentRepository.Create(comment);
                if (result == null) return BadRequest();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Error while creating new record");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Comment>> Update(Guid id,Comment comment)
        {
            try
            {
                var result = await commentRepository.Update(id,comment);
                if (result == null) return NotFound($"The comment with ID {id} not Found");
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Error while updating the record");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await commentRepository.FindById(id);
                if (result == null) return NotFound($"The comment with ID {id} not Found");
                await commentRepository.Delete(id);
                return Ok($"The Comment with ID {id} has been deleted successfully");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Error while deleting the record");
            }
        }
    }
}