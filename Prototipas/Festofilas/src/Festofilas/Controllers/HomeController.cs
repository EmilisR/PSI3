using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Festofilas.Data;
using Festofilas.Data.Model;
using Festofilas.Helpers;
using Festofilas.Models.JsonModels;
using Festofilas.Models.MainViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Festofilas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            var articles = _context.Articles.Select(x => new ArticleThumbModel() { Image64 = x.Image64, Name = x.Name, Id = x.Id, Summary = x.Summary, SubmissionTime = x.SubmissionTime.Value }).ToList().OrderByDescending(x => x.SubmissionTime).ToList();
            return View(articles);
        }

        public IActionResult About()
        {
            var festivals = _context.Festivals.Select(x => new FestivalThumbModel() { Id = x.Id, Name = x.Name, Genre = x.Genre.Value, Image = x.Image64, Date = x.Date.Value }).ToList();
            return View(festivals);
        }

        public IActionResult Contact()
        {
            //var appName = "Wow";
            //DataTable dt = new DataTable();
            //using (SqlConnection sqlConn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            //{
            //    using (SqlCommand sqlCmd = new SqlCommand("Select * from Comments where Text like '%@Param%'", sqlConn))
            //    {
            //        sqlCmd.CommandType = CommandType.Text;
            //        sqlCmd.Parameters.AddWithValue("@Param", appName);
            //        sqlConn.Open();
            //        using (var sqlAdapter = new SqlDataAdapter(sqlCmd))
            //        {
            //            sqlAdapter.Fill(dt);
            //        }
            //    }
            //}

            var comments =
                _context.Comments.Select(
                    x => new CommentAndArticleLink() { Comments = 
                        new CommentViewModel()
                        {
                            Text = x.Text,
                            Date = x.Date,
                            UserName = _context.Users.FirstOrDefault(y => y.Id == x.WritterId).UserName
                        }, ArticleLink = x.GetLink()
                        
                        });
            var users =
                _context.Users.Select(x => new { UserId = x.Id, UserName = x.UserName });

            var distinctItems =
                from list in users
                group list by list.UserId
                into grouped
                where grouped.Count() == 1
                select grouped;


            var result =
                    (from a in users
                     join b in comments on a.UserName equals b.Comments.UserName
                     group new CommentsByUsers { A = a.UserName, B = b } by a.UserName)
                    .ToDictionary(g => g.Key,
                                   g => g.Select(t => t.B)); ;
            return View(new ContactViewModel() { Dict = result, AmountOfUsers = distinctItems.Count() });
        }

        public IActionResult DeleteComment(string comment, string userName)
        {
            var id = _context.Users.FirstOrDefault(x=>x.UserName == userName).Id;
            var commentar = _context.Comments.FirstOrDefault(x => x.WritterId == id && x.Text == comment);
            _context.Comments.Remove(commentar);
            _context.SaveChanges();
            return Redirect("/Home/Contact");

        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult UpdateRating(int id, double vote)
        {
            if (ModelState.IsValid)
            {
                var fester = _context.Festivals.FirstOrDefault(x => x.Id == id);
                fester.NumberOfVotes++;
                fester.TotalScore += vote;
                _context.Festivals.Update(fester);
                _context.SaveChanges();
            }
            return Redirect("/Home/Festival/" + id);
        }
        [Authorize]
        public IActionResult AddFestival()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddArticle()
        {
            var list = new List<string>();
            list.AddRange(_context.Festivals.Select(x => new string(x.Name.ToCharArray())));
            ViewBag.Festivals = new SelectList(list);
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddArticle(ArticleViewModel item, IFormFile image)
        {
            int ide = 0;
            if (ModelState.IsValid)
            {
                var article = new Article()
                {
                    Name = item.Name,
                    SubmissionTime = item.SubmissionTime,
                    Summary = item.Summary,
                    Text = item.Text,
                    WritersId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };
                if (image != null)
                {
                    using (var fileStream = image.OpenReadStream())
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var s = Convert.ToBase64String(fileBytes);
                        article.Image64 = @"data:image/png;base64," + s;
                    }
                }
                _context.Articles.Add(article);
                _context.SaveChanges();
                if (article.ArticleFestivals == null)
                {
                    article.ArticleFestivals = new List<ArticleFestival>();
                }
                foreach (var id in item.FestivalNames)
                {
                    var number = _context.Festivals.FirstOrDefault(x => x.Name == id);
                    article.ArticleFestivals.Add(new ArticleFestival() { ArticleId = article.Id, FestivalId = number.Id, Festival = number, Article = article });
                }

                _context.SaveChanges();
                ide = article.Id;
            }
            return RedirectToAction($"Article/{ide}");
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddFestival(FestivalViewModel item, IFormFile image)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                var festival = new Festival()
                {
                    Name = item.Name,
                    Date = item.Date,
                    Genre = item.Genre,
                    LowestPrice = item.LowestPrice,
                    HighestPrice = item.HighestPrice,
                    Summary = item.Summary,
                    NumberOfVotes = item.NumberOfVotes,
                    WidgetCode = item.WidgetCode,
                    TotalScore = item.TotalScore,
                    TicketWebsite = item.TicketWebsite,
                    Webpage = item.Webpage,
                    ContactsJson = new Contacts() { Email = item.Email, Facebook = item.Facebook, FirstName = item.FirstName, LastName = item.LastName, PhoneNumber = item.PhoneNumber }.Serialize(),
                    LocationJson = new Location() { Latitude = item.Latitude, Longitude = item.Longitude, PlainTextAddress = item.PlainTextAddress }.Serialize()
                };
                if (image != null)
                {
                    using (var fileStream = image.OpenReadStream())
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var s = Convert.ToBase64String(fileBytes);
                        festival.Image64 = @"data:image/png;base64," + s;
                    }
                }
                _context.Festivals.Add(festival);
                _context.SaveChanges();
                id = festival.Id;
            }
            return RedirectToAction($"Festival/{id}");
        }
        public IActionResult EditFestival(int id)
        {
            var festival = _context.Festivals.FirstOrDefault(x => x.Id == id);
            return View(festival.ToFestivalViewModel());
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditFestival(FestivalViewModel item, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var fester = _context.Festivals.FirstOrDefault(x => x.Id == item.Id);
                var imaging = fester.Image64;
                fester.Id = fester.Id;
                fester.Name = item.Name;
                fester.Date = item.Date;
                fester.Genre = item.Genre;
                fester.LowestPrice = item.LowestPrice;
                fester.HighestPrice = item.HighestPrice;
                fester.Summary = item.Summary;
                fester.NumberOfVotes = item.NumberOfVotes;
                fester.WidgetCode = item.WidgetCode;
                fester.TotalScore = item.TotalScore;
                fester.TicketWebsite = item.TicketWebsite;
                fester.Webpage = item.Webpage;
                fester.ContactsJson =
                    new Contacts()
                    {
                        Email = item.Email,
                        Facebook = item.Facebook,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber
                    }.Serialize();
                fester.LocationJson =
                    new Location()
                    {
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        PlainTextAddress = item.PlainTextAddress
                    }.Serialize();

                if (image != null)
                {
                    using (var fileStream = image.OpenReadStream())
                    using (var ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var s = Convert.ToBase64String(fileBytes);
                        fester.Image64 = @"data:image/png;base64," + s;
                    }
                }
                else
                {
                    fester.Image64 = imaging;
                }
                _context.Festivals.Update(fester);
                _context.SaveChanges();
            }
            return RedirectToAction($"Festival/{item.Id}");

        }
        public IActionResult Festival(int id)
        {
            var festival = _context.Festivals.FirstOrDefault(x => x.Id == id);
            return View(festival.ToFestivalViewModel());
        }
        [Route("Home/Article/{articleId}")]
        public IActionResult Article(int articleId)
        {
            var model = _context.Articles.FirstOrDefault(x => x.Id == articleId);
            var article = new ArticleViewModel()
            {
                WriterUserName = _context.Users.FirstOrDefault(y => y.Id == model.WritersId).UserName,
                Name = model.Name,
                Id = model.Id,
                DisplayImage = model.Image64,
                SubmissionTime = model.SubmissionTime.Value,
                Summary = model.Summary,
                Text = model.Text,
                Festivals = _context.Festivals.Where(x => x.Id == model.Id).Select(x => new FestivalThumbModel() { Id = x.Id, Name = x.Name, Genre = x.Genre.Value, Image = x.Image64, Date = x.Date.Value }).ToList()
            };
            return View(article);
        }
        [Authorize]
        [HttpPost]
        public IActionResult PostComment(CommentPostModel commentPostModel)
        {
            if (ModelState.IsValid)
            {
                var com = new Comment()
                {
                    ArticleId = commentPostModel.ArticleId,
                    Date = DateTime.Now,
                    IsFestival = commentPostModel.IsFestival,
                    Text = commentPostModel.Comment,
                    WritterId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };
                _context.Comments.Add(com);
                _context.SaveChanges();
            }
            return Redirect(commentPostModel.IsFestival ? $"/Home/Festival/{commentPostModel.ArticleId}" : $"/Home/Article/{commentPostModel.ArticleId}");
        }
    }
}
