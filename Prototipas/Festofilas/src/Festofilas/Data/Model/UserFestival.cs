using Festofilas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Festofilas.Data.Model
{
    public class UserFestival
    {
        [ForeignKey("Festival")]
        public int FestivalId { get; set; }
        public Festival Festival { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
