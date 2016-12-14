using System.Globalization;
using System.Linq;
using Festofilas.Data;
using Festofilas.Models.MainViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace Festofilas.Controllers
{
    public class CommentViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CommentViewComponent(ApplicationDbContext db)
        {
            _context = db;
        }
        public IViewComponentResult Invoke(int articleId, bool isFestival, int from, int to)
        {
            var comments = _context.Comments.Where(x=>x.ArticleId == articleId && x.IsFestival == isFestival).Select(x => new CommentViewModel() { Text = x.Text, Date = x.Date, UserName = _context.Users.FirstOrDefault(y => y.Id == x.WritterId).UserName });
            comments = comments.OrderByDescending(x => x.Date);
            return View(comments.Skip(from).Take(to).ToList());
        }
    }
}