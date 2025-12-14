using System;

class CPU
{
    public void Freeze()
    {
        Console.WriteLine("Stops running processes...");
    }
    
    public void Execute()
    {
        Console.WriteLine("Executes commands...");
    }
}

class HardDrive
{
    public void Read()
    {
        Console.WriteLine("Reads data from disk...");
    }
}

class RAM
{
    public void Load()
    {
        Console.WriteLine("Loads data into memory...");
    }
}

class Facade
{
    protected CPU cpu;
    protected HardDrive harddrive;
    protected RAM ram;
    
    public Facade()
    {
        cpu = new CPU();
        harddrive = new HardDrive();
        ram = new RAM();  
    }
    
    public void StartComputer()
    {
        Console.WriteLine("Starting Computer...");
        cpu.Freeze();
        harddrive.Read();
        ram.Load();
        cpu.Execute();
        Console.WriteLine("Computer started!\n");
    }
    
    public void StopComputer() 
    {
        Console.WriteLine("Turning off the computer...");
        Console.WriteLine("Computer is off.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.StartComputer();
        facade.StopComputer();
    }
}
