using System;
namespace Strategy;

interface DriveMode
{
    void Speed();
    void Consumption();
}

class EcoMode : DriveMode
{
    public void Speed() => Console.WriteLine("We drive slowly.");
    public void Consumption() => Console.WriteLine(("Consumption isn't high."));
}
class NormalMode : DriveMode
{
    public void Speed() => Console.WriteLine("We drive.");
    public void Consumption() => Console.WriteLine("Average consumption.");
}

class SportMode : DriveMode
{
    public void Speed() => Console.WriteLine("We drive fast.");
    public void Consumption() => Console.WriteLine("Consumption is high.");
}

class Car
{
    private DriveMode _mode;

    public void SetDriveMode(DriveMode mode)
    {
        _mode = mode;
    }

    public void Drive()
    {
        if (_mode == null)
        {
            Console.WriteLine("Not selected driving mode!");
        }
        else
        {
            Console.WriteLine($"Drive mode is: {_mode.GetType().Name}");
            _mode.Speed();
            _mode.Consumption();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();

        car.SetDriveMode(new EcoMode());
        car.Drive();
        Console.WriteLine();
        car.SetDriveMode(new SportMode());
        car.Drive();
    }
}