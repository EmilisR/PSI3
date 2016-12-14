using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Festofilas.Data;
using Festofilas.Models.MainViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festofilas.Controllers
{
    public class FestivalThumbnailsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public FestivalThumbnailsViewComponent(ApplicationDbContext db)
        {
            _context = db;
        }
        public IViewComponentResult Invoke(int articleId)
        {
            var person = _context.Articles.Include(y => y.ArticleFestivals).First(x => x.Id == articleId);
            if (person.ArticleFestivals == null)
            {
                return View(new List<FestivalThumbModel>());
            }
            var ids = person.ArticleFestivals.Select(x => x.ArticleId);
            var festivals = ids.Select(id => _context.Festivals.First(x => x.Id == id)).ToList();
            var festiv = festivals.Select(fest => new FestivalThumbModel() {Id = fest.Id, Name = fest.Name, Date = fest.Date.Value, Genre = fest.Genre.Value, Image = fest.Image64}).Take(4);
            return View(festiv.ToList());
        }
    }
}