using System;

namespace Festofilas.Models.MainViewModels
{
    public class CommentViewModel
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserName { get; set; }
        public int from { get; set; } = 0;
        public int to { get; set; } = 5;
    }
}