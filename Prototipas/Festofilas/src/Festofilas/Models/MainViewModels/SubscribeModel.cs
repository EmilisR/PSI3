using Festofilas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festofilas.Models.MainViewModels
{
    public class SubscribeModel
    {
        public List<Festival> Festivals { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<UserFestival> UserFestivals { get; set; }
    }
}
