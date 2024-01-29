using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF.Models
{
    [Table("articletag")]
    public class ArticleTag
    {
        [Key]
        public int ArticleTagId { set; get; }

        public int ArticleId { set; get; }
        [ForeignKey("ArticleId")]
        public Article article { set; get; }

        [StringLength(20)]
        public string TagId { set; get; }
        [ForeignKey("TagId")]
        public Tag tag { set; get; }
    }
}
