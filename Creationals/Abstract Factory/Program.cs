using System;
using System.Formats.Asn1;
interface INotebook
{
    void WriteDown();
}
interface IPen
{
    void Write();
}
class KiteNotebook : INotebook
{
    public void WriteDown() => Console.WriteLine("We write in the Kite notebook");
}
class KitePen : IPen
{
    public void Write() => Console.WriteLine("We write with a Kite pen");
}
class KohINoorNotebook : INotebook
{
    public void WriteDown() => Console.WriteLine("We write in the Koh-I-Noor notebook");
}
class KohINoorPen : IPen
{
    public void Write() => Console.WriteLine("We write with a Koh-I-Noor pen");
}
interface IStationeryFactory
{
    INotebook CreateNotebook();
    IPen CreatePen();
}
class KiteStationeryFactory : IStationeryFactory
{
    public INotebook CreateNotebook() => new KiteNotebook();
    public IPen CreatePen() => new KitePen();
}
class KohINoorStationeryFactory : IStationeryFactory
{
    public INotebook CreateNotebook() => new KohINoorNotebook();
    public IPen CreatePen() => new KohINoorPen(); 
}
class Program
{
    static void Main(string[] args)
    {
        IStationeryFactory factory;
        Console.WriteLine("Choose a company: (Kite or Koh-I-Noor)");
        string? company = Console.ReadLine().ToLower();
        if (company == "kite")
        {
            factory = new KiteStationeryFactory();
        }
        else factory = new KohINoorStationeryFactory();
        INotebook notebook = factory.CreateNotebook();
        IPen pen = factory.CreatePen();
        notebook.WriteDown();
        pen.Write();
    }
}