using System;
using Festofilas.Data.Model;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Festofilas.Models.MainViewModels
{
    public class FestivalViewModel
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public GenreEnum Genre { get; set; }

        public double LowestPrice { get; set; }

        public double HighestPrice { get; set; }

        public string Webpage { get; set; }

        public string PlainTextAddress { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string TicketWebsite { get; set; }
        public ImageTagHelper Image { get; set; }

        public string Summary { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Facebook { get; set; }

        public string DisplayImage { get; set; }
        public int Id { get; set; }
        public double TotalScore { get; set; }
        public int NumberOfVotes { get; set; }
        public string WidgetCode { get; set; }
        public double Rate
        {
            get { return Math.Round(TotalScore / NumberOfVotes, 2) > 0 ? Math.Round(TotalScore / NumberOfVotes, 2) : 0; }
        }
        public void updateNumberOfVotes()
        {
            NumberOfVotes++;
        }
    }
}