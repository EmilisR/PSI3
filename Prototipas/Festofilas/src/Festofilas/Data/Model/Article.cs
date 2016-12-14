using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Festofilas.Data.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image64 { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public ICollection<ArticleFestival> ArticleFestivals { get; set; }
        public string WritersId { get; set; }
    }
}