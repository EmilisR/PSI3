using System;
using System.ComponentModel.DataAnnotations;

namespace Festofilas.Data.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string WritterId { get; set; }
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public bool IsFestival { get; set; }
        public DateTime Date { get; set; }
    }
}