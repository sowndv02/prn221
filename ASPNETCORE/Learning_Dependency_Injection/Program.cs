internal class Program
{
    // DI: Triển khai từ Ioc
    // Dependency: Có class A thì class B mới hoạt động được


    // Inversion Of Control: Thay vì tham chiếu trực tiếp đến class thì sẽ tham chiếu gián tiếp qua 1 interface


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

    //private static void Main(string[] args)
    //{
        
    //    // Cách bth
    //    var c = new ClassC();
    //    var b = new ClassB(c);
    //    var a = new ClassA(b);
    //    a.ActionA();

    //    // khi sd IoC
    //    IClassC objectC = new ClassC();
    //    IClassB objectB = new ClassB(objectC);
    //    ClassA objectA = new ClassA(objectB);


    //    IClassC objectC1 = new ClassC1();            // new ClassC();
    //    IClassB objectB1 = new ClassB1(objectC1);     // new ClassB();
    //    ClassA objectA1 = new ClassA(objectB1);
    //}


    

}