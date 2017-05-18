using System;
using Festofilas.Data.Model;
using Festofilas.Models.JsonModels;
using Festofilas.Models.MainViewModels;

namespace Festofilas.Helpers
{
    public static class Extensions
    {

        public static FestivalViewModel ToFestivalViewModel(this Festival festival)
        {
            var contact = new Contacts();
            contact.Populate(festival.ContactsJson);
            var location = new Location();
            location.Populate(festival.LocationJson);
            return new FestivalViewModel()
            {
                Id = festival.Id,
                Genre = festival.Genre.Value,
                Name = festival.Name,
                Date = festival.Date.Value,
                PhoneNumber = contact.PhoneNumber,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PlainTextAddress = location.PlainTextAddress,
                Facebook = contact.Facebook,
                DisplayImage = festival.Image64,
                Email = contact.Email,
                HighestPrice = festival.HighestPrice,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                LowestPrice = festival.LowestPrice,
                Summary = festival.Summary,
                TotalScore = festival.TotalScore,
                NumberOfVotes = festival.NumberOfVotes,
                TicketWebsite = festival.TicketWebsite,
                Webpage = festival.Webpage
            };
        }

        public static string GetLink(this Comment comment)
        {
            var str = "/Home";
            if (comment.IsFestival)
            {
                str += "/Festival/";
            }
            else
            {
                str += "/Article/";
            }
            str += comment.ArticleId;
            return str;
        }
    }
}