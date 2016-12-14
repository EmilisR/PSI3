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
        public int? LowestPrice { get; set; }
        public int? HighestPrice { get; set; }
        public string Webpage { get; set; }
        public string LocationJson { get; set; }
        public string ContactsJson { get; set; }
        public string TicketWebsite { get; set; }
        public string Image64 { get; set; }
        public string Summary { get; set; }

        public ICollection<ArticleFestival> ArticleFestivals { get; set; }
    }
}