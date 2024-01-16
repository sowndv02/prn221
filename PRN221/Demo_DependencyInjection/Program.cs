
class DongCoOtoTQ : IDongCo
{
    public void NoMay()
    {
        Console.WriteLine("Dong co dang chay");
    }
}

class DongCoOtoMy : IDongCo
{
    public void NoMay()
    {
        Console.WriteLine("Dong co dang chay");
    }
}


interface IDongCo
{
    public void NoMay();
}
class Oto
{
    public void DiChuyen(IDongCo dongco)
    {
        dongco.NoMay();
        Console.WriteLine("Xe di chuyen");
    }

    public static void Main(string[] args)
    {
        IDongCo dc = new DongCoOtoTQ();
        Oto oto = new Oto();
        oto.DiChuyen(dc);
        Console.ReadLine();
    }
}