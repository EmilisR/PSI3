using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Festofilas.Data.Model
{
    public class Festival
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public GenreEnum? Genre { get; set; }
        public double LowestPrice { get; set; }
        public double HighestPrice { get; set; }
        public string Webpage { get; set; }
        public string LocationJson { get; set; }
        public string ContactsJson { get; set; }
        public string TicketWebsite { get; set; }
        public string Image64 { get; set; }
        public string Summary { get; set; }
        public double TotalScore { get; set; }
        public int NumberOfVotes { get; set; }
        public string WidgetCode { get; set; }
        public double Rate
        {
            get { return Math.Round(TotalScore/NumberOfVotes, 2) > 0? Math.Round(TotalScore / NumberOfVotes, 2) : 0; }
        }

        public ICollection<ArticleFestival> ArticleFestivals { get; set; }
    }
}