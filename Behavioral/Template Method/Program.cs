using System;
using System.Security.Cryptography.X509Certificates;

namespace Template_Method;

abstract class Weapon
{
    protected string Name;
    protected int AmmoInMagazine;
    protected int MagazineSize;

    protected virtual bool CanFire()
    {
        return AmmoInMagazine > 0;
    }

    protected abstract void Shoot();

    public void Reload()
    {
        AmmoInMagazine = MagazineSize;
        Console.WriteLine("Reloaded!");
    }

    public Weapon(string Name, int MagazineSize)
    {
        this.Name = Name;
        this.MagazineSize = MagazineSize;
        AmmoInMagazine = MagazineSize;
    }

    public void Fire()
    {
        if (!CanFire())
        {
            Console.WriteLine("Need reload!");
            Reload();
            return;
        }
        Shoot();
    }

    public void ShowAmmo()
    {
        Console.WriteLine($"Ammo in magazine: {AmmoInMagazine} / {MagazineSize}");
    }
}

class Pistol : Weapon
{
    public Pistol() : base("Pistol", 12) { }

    protected override void Shoot()
    {
        AmmoInMagazine--;
        Console.WriteLine($"{Name}: Bang!!!");
    }
}

class Shotgun : Weapon
{
    public Shotgun() : base("Shotgun", 6) { }

    protected override void Shoot()
    {
        AmmoInMagazine--;
        Console.WriteLine($"{Name}: Boom!!!");
    }
}

class Sniper : Weapon
{
    public Sniper():base("Sniper",10) { }

    protected override void Shoot()
    {
        AmmoInMagazine--;
        Console.WriteLine($"{Name}: Piu!!!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Weapon pistol = new Pistol();
        Weapon shotgun = new Shotgun();
        Weapon sniper = new Sniper();
        for (int i = 0; i < 13; i++)
        {
            pistol.Fire();
            if (i == 5)
            {
                pistol.Reload();
                pistol.ShowAmmo();
            }
        }
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            shotgun.Fire();
        }
        Console.WriteLine();
        sniper.Fire();
        sniper.ShowAmmo();
    }
}