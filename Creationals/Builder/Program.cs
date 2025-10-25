using System;
using System.Runtime.InteropServices;
class Computer
{
    public string Processor { get; set; }
    public string Motherboard { get; set; }
    public string RAM { get; set; }
    public string HardDrive { get; set; } 
    public string VideoCard {  get; set; }
    public string PowerUnit { get; set; }
    public string CoolingSystem { get; set; }
    public string Case {  get; set; }
    public void ShowInfo()
    {
        Console.WriteLine($"Processor: {Processor}");
        Console.WriteLine($"Motherboard: {Motherboard}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Hard Drive: {HardDrive}");
        Console.WriteLine($"Video Card: {VideoCard}");
        Console.WriteLine($"Power Unit: {PowerUnit}"); 
        Console.WriteLine($"Cooling System: {CoolingSystem}");
        Console.WriteLine($"Case: {Case}");
    }
}
interface ICompBuilder
{
    void SetCPU();
    void SetMotherboard();
    void SetRAM();
    void SetHardDrive();
    void SetGPU();
    void SetPSU();
    void SetCoolingSystem();
    void SetCase();
    Computer GetComputer();
}
class OfficePCBuilder : ICompBuilder
{
    private Computer computer = new Computer();
    public void SetCPU() => computer.Processor = "AMD Ryzen 5 8600G";
    public void SetMotherboard() => computer.Motherboard = "Gigabyte B650M DS3H";
    public void SetRAM() => computer.RAM = "16 Gb DDR4 3200 MHz (Kingston Fury Beast)";
    public void SetHardDrive() => computer.HardDrive = "500 Gb NVMe (Kingston NV2)";
    public void SetGPU() => computer.VideoCard = "Integral graphics Radeon 760M";
    public void SetPSU() => computer.PowerUnit = "450W 80+ Bronze (AeroCool VX)";
    public void SetCoolingSystem() => computer.CoolingSystem = "DeepCool AK620";
    public void SetCase() => computer.Case = "Fractal North XL Dark TG Full Tower Case - Black";
    public Computer GetComputer() => computer;
}
class GamePCBuilder : ICompBuilder
{
    private Computer computer = new Computer();
    public void SetCPU() => computer.Processor = "AMD Ryzen 7 7800X3D";
    public void SetMotherboard() => computer.Motherboard = "GIGABYTE B650 AORUS ELITE AX V2";
    public void SetRAM() => computer.RAM = "32 Gb DDR5 6400 MHz (CL32)";
    public void SetHardDrive() => computer.HardDrive = "2 TB PCIe 4.0 (Samsung 990 Pro)";
    public void SetGPU() => computer.VideoCard = "NVIDIA RTX 4080 Super";
    public void SetPSU() => computer.PowerUnit = "850W 80+ Platinum (Corsair RMx)";
    public void SetCoolingSystem() => computer.CoolingSystem = "Arctic Liquid Freezer II 420";
    public void SetCase() => computer.Case = "Lian Li Lancool 216";
    public Computer GetComputer() => computer;
}
class Director
{
    public void Construct(ICompBuilder builder)
    {
        builder.SetCPU();
        builder.SetMotherboard();
        builder.SetRAM();
        builder.SetHardDrive();
        builder.SetGPU();
        builder.SetPSU();
        builder.SetCoolingSystem();
        builder.SetCase();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Director director = new Director();
        ICompBuilder officeBuilder = new OfficePCBuilder();
        director.Construct(officeBuilder);
        Computer officeComputer = officeBuilder.GetComputer();
        Console.WriteLine("Office Computer:");
        officeComputer.ShowInfo();

        ICompBuilder gameBuilder = new GamePCBuilder();
        director.Construct(gameBuilder);
        Computer gameComputer = gameBuilder.GetComputer();
        Console.WriteLine("\nGame Computer:");
        gameComputer.ShowInfo();
    }
}