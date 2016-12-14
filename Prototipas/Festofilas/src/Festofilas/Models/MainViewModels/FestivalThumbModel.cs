using System;
using Festofilas.Data.Model;

namespace Festofilas.Models.MainViewModels
{
    public class FestivalThumbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreEnum Genre { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
    }
}