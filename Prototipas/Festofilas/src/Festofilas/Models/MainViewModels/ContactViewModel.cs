using System.Collections.Generic;
using Festofilas.Controllers;

namespace Festofilas.Models.MainViewModels
{
    public class ContactViewModel
    {
        public Dictionary<string, IEnumerable<CommentAndArticleLink>> Dict { get; set; }

        public int AmountOfUsers { get; set; }
    }
}