using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        //[Column(TypeName = "ntext")]
        [Column("ProductName", TypeName = "ntext")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }

        // nếu dể như này cũng vẫn không thay đổi việc cateId là khóa ngoại và kh tạo duplicated attribute này
        public int? CateId { get; set; } 
        // Foregin key
        [ForeignKey("CateId")]
        [Required]
        public virtual Category Category { get; set; } // FK

        // Nếu kh cho phép CateId2 null thì sẽ tạo ra vòng lặp del trong sql server vì vậy phải set nó được null do đang tạo 2 khóa ngoại
        public int CateId2 { get; set; }
        // Foregin key
        [ForeignKey("CateId2")]
        [Required]
        [InverseProperty("Products")]
        public virtual Category Category2 { get; set; } // FK
        public void PrintInfo() => Console.WriteLine($"{Id} - {Name} - {Price}");
    }


    /*
     
    [Table("TableName")] -- Set name trên sql server
    [Key] - Coi trường đó là primary key
    [Required] - Not null
    [StringLength(50)] - nvarchar
    [Column(TypeName = "ntext")] - Set kiểu dữ liệu trên sql server
    [Column("ProductName", TypeName = "ntext")] - Cột có tên là productName kiểu dữ liệu là ntext
    [ForeignKey("CateId")] - Set lại name của khóa ngoại trong bảng Product
    [InverseProperty("Products")] : Nếu có 2 khóa ngoại khi get sẽ lấy Products theo cateId nào


     */
}
