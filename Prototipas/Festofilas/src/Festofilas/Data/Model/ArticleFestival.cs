using System.ComponentModel.DataAnnotations.Schema;

namespace Festofilas.Data.Model
{
    public class ArticleFestival
    {
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        [ForeignKey("Festival")]
        public int FestivalId { get; set; }
        public Festival Festival { get; set; }
    }
}