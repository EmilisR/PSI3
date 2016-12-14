using System;

namespace Festofilas.Models.MainViewModels
{
    public class ArticleThumbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image64 { get; set; }
        public string Summary { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}