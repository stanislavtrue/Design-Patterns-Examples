using System;
using System.Security.Authentication;
class Car
{
    public string Brand;
    public string Model;
    public DateTime ReleaseDate;
    public Car ShallowCopy()
    {
        return (Car)this.MemberwiseClone();
    }
    public Car DeepCopy()
    {
        Car clone = (Car)this.MemberwiseClone();
        clone.Brand = String.Copy(Brand);
        clone.Model = String.Copy(Model);
        return clone;
    }
}
class Program
{
    static void ShowValues(Car car)
    {
        Console.WriteLine($"Brand: {car.Brand}\nModel: {car.Model}\nRelease Date: {car.ReleaseDate}");
    }
    static void Main(string[] args)
    {
        Car car1 = new Car();
        car1.Brand = "Bugatti";
        car1.Model = "Veyron";
        car1.ReleaseDate = Convert.ToDateTime("2005-09-01");
        Car car2 = car1.ShallowCopy();
        Car car3 = car1.DeepCopy();
        Console.WriteLine("Original values of car1, car2, car3:");
        Console.WriteLine("Car 1:");
        ShowValues(car1);
        Console.WriteLine("Car 2:");
        ShowValues(car2);
        Console.WriteLine("Car 3:");
        ShowValues(car3);

        car1.Brand = "Bugatti";
        car1.Model = "Bolide";
        car1.ReleaseDate = Convert.ToDateTime("2025-02-01");
        Console.WriteLine("\nValues of car1, car2, car3 after changes to car1:");
        Console.WriteLine("Car1:");
        ShowValues(car1);
        Console.WriteLine("Car2:");
        ShowValues(car2);
        Console.WriteLine("Car3:");
        ShowValues(car3);
    }
}