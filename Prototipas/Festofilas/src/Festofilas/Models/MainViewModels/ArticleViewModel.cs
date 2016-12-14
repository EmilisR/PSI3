using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Festofilas.Models.MainViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayImage { get; set; }
        public ImageTagHelper Image { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public DateTime SubmissionTime { get; set; }
        public IEnumerable<string> FestivalNames { get; set; }
        public string WriterUserName { get; set; }
        public List<FestivalThumbModel> Festivals { get; set; }
    }
}