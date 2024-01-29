using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Dependency_Injection
{
    public class ImplemetnDI
    {

        // Phải có Microsoft.Extensions.DependencyInjection

        /*
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            
             
            // Đăng ký dịch vụ
            // IClassC, ClassC, ClassC1


            // Singleton: Tạo ra 1 lần và sử dụng nó
            services.AddSingleton<IClassC, ClassC1>();


            // Transient: mỗi lần gọi sẽ tạo ra 1 dịch vụ
            services.AddTransient<IClassC, ClassC>();

            // Scoped: Trong mỗi phạm vi chỉ có 1 service được tạo ra

            var provider = services.BuildServiceProvider();



            // var classC = provider.GetService<IClassC>();

            for(int i = 0; i < 5; i++)
            {
                IClassC c = provider.GetService<IClassC>();
                Console.WriteLine(c.GetHashCode());
            }



            // tạo ra 1 scope
            using(var scope = provider.CreateScope())
            {
                var provider1 = services.BuildServiceProvider();
                for (int i = 0; i < 5; i++)
                {
                    IClassC c = provider1.GetService<IClassC>();
                    Console.WriteLine(c.GetHashCode());
                }
            }             
             
             
             



            // Tự động tạo và inject vào dịch vụ
            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<IClassB, ClassB>();
            services.AddSingleton<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();
            ClassA a = provider.GetService<ClassA>();
            a.ActionA();


            // Đăng ký sử dụng delegate 
            services.AddSingleton<IClassB, ClassB2>(
                (proviđer) =>
                {
                    var b2 = new ClassB2(
                        provider.GetService<IClassC>(),
                        "Thực hiện trong ClassB2"
                        );
                    return b2;
                }
            );
            // services.AddSingleton<string, string>();    // Lỗi => dùng delegate
            
            // Sử dụng factory
            services.AddSingleton<IClassB>(CreateB2);
        }

        */

        //  Những class chuyên để tạo ra đối tượng của service là factory
        static IClassB CreateB2(IServiceProvider provider)
        {
            var b2 = new ClassB2(
                        provider.GetService<IClassC>(),
                        "Thực hiện trong ClassB2"
                        );
            return b2;
        }


        class ClassB2 : IClassB
        {
            IClassC c_dependency;
            string message;
            public ClassB2(IClassC classc, string mgs)
            {
                c_dependency = classc;
                message = mgs;
                Console.WriteLine("ClassB2 is created");
            }
            public void ActionB()
            {
                Console.WriteLine(message);
                c_dependency.ActionC();
            }
        }

            interface IClassB
        {
            public void ActionB();
        }
        interface IClassC
        {
            public void ActionC();
        }

        class ClassC : IClassC
        {
            public ClassC() => Console.WriteLine("ClassC is created");
            public void ActionC() => Console.WriteLine("Action in ClassC");
        }

        class ClassB : IClassB
        {
            IClassC c_dependency;
            public ClassB(IClassC classc)
            {
                c_dependency = classc;
                Console.WriteLine("ClassB is created");
            }
            public void ActionB()
            {
                Console.WriteLine("Action in ClassB");
                c_dependency.ActionC();
            }
        }

        class ClassA
        {
            IClassB b_dependency;
            public ClassA(IClassB classb)
            {
                b_dependency = classb;
                Console.WriteLine("ClassA is created");
            }
            public void ActionA()
            {
                Console.WriteLine("Action in ClassA");
                b_dependency.ActionB();
            }

        }

        class ClassC1 : IClassC
        {
            public ClassC1() => Console.WriteLine("ClassC1 is created");
            public void ActionC()
            {
                Console.WriteLine("Action in C1");
            }
        }

        class ClassB1 : IClassB
        {
            IClassC c_dependency;
            public ClassB1(IClassC classc)
            {
                c_dependency = classc;
                Console.WriteLine("ClassB1 is created");
            }
            public void ActionB()
            {
                Console.WriteLine("Action in B1");
                c_dependency.ActionC();
            }
        }
    }
}
