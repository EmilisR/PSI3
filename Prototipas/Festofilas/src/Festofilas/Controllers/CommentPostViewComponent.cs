using System;
using Festofilas.Models.MainViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Festofilas.Controllers
{
    public class CommentPostViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CommentPostModel comment)
        {
            var str = string.Empty;
            comment.Comment = str;

            return View(comment);
        }

    }
}