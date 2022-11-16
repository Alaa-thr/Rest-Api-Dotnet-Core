using System;
using System.ComponentModel.DataAnnotations;
//install System.ComponentModel.Annotations
namespace rest_api_dotnet_core.Models
{
    public class Comment
    {
        public Guid Id { get; set; } // Guid means unique id
        [Required]
        [MinLength(10,ErrorMessage ="The text mush have at least 10 caracters")]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
