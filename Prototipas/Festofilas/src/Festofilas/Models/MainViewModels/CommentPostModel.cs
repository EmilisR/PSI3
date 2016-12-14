using System.ComponentModel.DataAnnotations;

namespace Festofilas.Models.MainViewModels
{
    public class CommentPostModel
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public bool IsFestival { get; set; }   
    }
}