using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Dependency_Injection
{

    // Làm sao để triển khai code có khả năng áp dụng DI

    // Inject qua hàm tạo => Được .Net hỗ trợ sẵn
    // Inject qua setter
    // Inject qua interface

    public class HowToImplementDI
    {
        //public static void Main(string[] args)
        //{
        //    //var car = new Car();
        //    //car.Beep();



        //    // Thư viện hỗ trợ DI => DI conteiner : ServiceCollection
        //    // Đăng ký các dịch vụ => ServiceProvider =>  hỗ trợ lấy ra các service. 
        //    // Khi lấy ra sẽ khởi tạo đối tượng. Nếu các đối tượng đó cần DI nếu chưa cho dependency thì sẽ tự tạo ra dependency và inject vào

        //    // Vòng đời của các service
        //    // -- Scoped (1): Một bản thực thi (instance) của dịch vụ (Class) được tạo ra cho mỗi phạm vi, tức tồn tại cùng với sự tồn tại của một đối tượng kiểu ServiceScope (đối tượng này tạo bằng cách gọi ServiceProvider.CreateScope, đối tượng này hủy thì dịch vụ cũng bị hủy).
        //    // -- Singleton (0): Duy nhất một phiên bản thực thi (instance of class) (dịch vụ) được tạo ra cho hết vòng đời của ServiceProvider
        //    // -- Transient (2): Một phiên bản của dịch vụ được tạo mỗi khi được yêu cầu
        //    Horn horn = new Horn();

        //    var car = new Car(horn); // horn inject vào car
        //    car.Beep(); // Beep - beep - beep ...
        //}
    }

    // Triển khai code không thể áp dụng DI
    // Nếu horn thay đổi thêm tham số là level thì sẽ phải sửa code ở Car

    //public class Horn
    //{
    //    public void Beep() => Console.WriteLine("Beep - beep - beep ...");
    //}

    //public class Car
    //{
    //    public void Beep()
    //    {
    //        // chức năng Beep xây dựng có định với Horn
    //        // tự tạo đối tượng horn (new) và dùng nó
    //        Horn horn = new Horn();
    //        horn.Beep();
    //    }
    //}


    // Thiết kế có khả năng sử dụng DI
    public class Horn
    {
        public void Beep() => Console.WriteLine("Beep - beep - beep ...");
    }

    public class Car
    {
        // horn là một Dependecy của Car
        Horn horn;

        // Inject theo phương thức khởi tạo
        // dependency Horn được đưa vào Car qua hàm khởi tạo
        public Car(Horn horn) => this.horn = horn;

        public void Beep()
        {
            // Sử dụng Dependecy đã được Inject
            horn.Beep();
        }
    }

}
