using System;

interface ICar
{
    string GetDescription();
    double GetPower();
}

class LamborghiniHuracanPerfomante : ICar
{
    public string GetDescription() => "Lamborghini Huracan Perfomante";
    public double GetPower() => 640;
}

abstract class LamborghiniHuracanPerfomanteDescription : ICar
{
    protected ICar car;
    
    public LamborghiniHuracanPerfomanteDescription(ICar car)
    {
        this.car = car;
    }
    
    public virtual string GetDescription() => car.GetDescription();
    public virtual double GetPower()=>car.GetPower();
}

class ChipTuning : LamborghiniHuracanPerfomanteDescription
{
    public ChipTuning(ICar car) : base(car) { }
    public override string GetDescription() => car.GetDescription() + ", Chip Tuning";
    public override double GetPower() => car.GetPower() + 40;
}

class TwinTurbo : LamborghiniHuracanPerfomanteDescription
{
    public TwinTurbo(ICar car) : base(car) { }
    public override string GetDescription() => car.GetDescription() + ", Twin Turbo";
    public override double GetPower() => car.GetPower() + 1400;
}

class Downpipes : LamborghiniHuracanPerfomanteDescription
{
    public Downpipes(ICar car) : base(car) { }
    public override string GetDescription() => car.GetDescription() + ", Downpipes";
    public override double GetPower() => car.GetPower() + 25;
}

class Program
{
    static void Main(string[] args)
    {
        ICar car = new LamborghiniHuracanPerfomante();
        Console.WriteLine($"{car.GetDescription()} - Power: {car.GetPower()} HP\n");
        car = new Downpipes(car);
        car = new ChipTuning(car);
        Console.WriteLine($"{car.GetDescription()} - Power: {car.GetPower()} HP\n");
        car = new TwinTurbo(car);
        Console.WriteLine($"{car.GetDescription()} - Power: {car.GetPower()} HP\n");
    }
}
