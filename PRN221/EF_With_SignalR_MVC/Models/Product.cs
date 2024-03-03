using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_With_SignalR_MVC.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdId {  get; set; }
        public string ProdName { get;set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQty { get; set; }

    }
}
