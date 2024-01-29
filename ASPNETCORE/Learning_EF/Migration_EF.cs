using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_EF
{
    public class Migration_EF
    {
        public static void Main(string[] args)
        {
            // migration: code => database


            /*
            - Lệnh tạo ra một Migration, giả sử đặt tên cho nó là NameMigration sử dụng lệnh sau:
            dotnet ef migrations add NameMigration
            Thay NameMigration bằng tên do bạn đặt, nó mang ý nghĩa như là phiên bản, nó cũng được dùng để đặt tên những lớp phát sinh.
            - Bản đầu tiên áp dụng cho ví dụ sẽ đặt tên là InitWebDB
            dotnet ef migrations add InitWebDB
            - Xem tất cả list migrations hiện có
            dotnet ef migratión list
           Note: Nếu ở 2 thời điểm tạo migration mà code kh đổi thì sẽ kh có ở file.cs ở Up and Down sẽ kh có code 
            - Xóa 1 migration gần nhất
            dotnet ef migration remove
            - Cập nhât migration lên DB
            dotnet ef database update 
            Note: Nếu kh nêu rõ tên migration thì sẽ update từ đầu đến cuối
            dotnet ef database update [MigrationName]
            - Xóa toàn bộ database 
            dotnet ef database drop -f
            Note: Nếu đổi datatype của PK từ string => int thì sẽ lỗi
            Để xử lý TH này thì tạo 1 properties mới và set nó làm key thì nó sẽ được cập nhật và sau đó đổi lại tên

            - Lấy ra tất cả script sql từ đầu đến cuối
            dotnet ef migration script
            Note: nếu kh để tên thì lấy tất. Còn muốn lấy từ vị trí nào đến vị trí nào thì \
            dotnet ef migration script MigrationName1 MigrationName2
            - Muốn lưu sql ra file
            dotnet ef migration script -o migration.sql


            - Trong TH có database r muốn sinh ra code biểu diễn model. 
            dotnet ef dbcontext scaffold -o Models -f -d "Data Source=localhost,1433;Initial Catalog=shopdata;User ID=SA;Password=Password123" "Microsoft.EntityFrameworkCore.SqlServer"

            -o Models thư mục lưu các entity được sinh ra
            -f cho phép ghi đè file
            -d ưu tiên sử dụng kỹ thuật Data Annotation nếu có thể - nếu không thể thì dùng FLuent API
            Cuối là chuỗi kết nối và thư viện sử dụng



            - Sau khi gen xong nếu tạo migration thì trên DB có r nếu update sẽ lỗi
            => Set trên DB là đã cập nhật
            Lấy script đc gen và lấy code chọn MigrationHistory và chạy trực tiếp trên DB

             */
        }
    }
}
