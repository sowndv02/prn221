using Learning_Razor_PageModel_ModelBinding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Learning_Razor_PageModel_ModelBinding.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //[DisplayName("Id ne")] // Hien thi a label 
        //[Range(10, 100, ErrorMessage ="Sai cmnr")] // Validation and message error
        //public int UserId { get; set; }
        //[DisplayName("Email cua mai")]
        //[EmailAddress(ErrorMessage = "Message sai cmnr")] // Check format email
        //public string Email { get; set; }

        // Binding object
        [BindProperty]
        public User user { get; set; }  

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public String Thongbao;

        // Chạy truy cập post tới, url = /sanpham/2?handler=xoa
        public void OnPostXoa([FromQuery(Name ="sanpham")]int i) // se tìm theo key = sanpham
        {
            Thongbao = "Gọi OnPostXoa";
        }
        // Chạy truy cập post tới, url = /sanpham/2?handler=soanthao
        public void OnPostSoanthao(int id)
        {
            Thongbao = "Gọi OnPostSoanthao";
        }
        // Chạy truy cập post tới, url = /sanpham/2?handler=xemchitiet
        public void OnPostXemchitiet(int id)
        {
            Thongbao = "Gọi OnPostXemchitiet";
        }

    }
}