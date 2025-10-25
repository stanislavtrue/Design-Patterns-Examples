using System;
using System.CodeDom.Compiler;
interface IEmployee
{
    void ShowDetails(int indent = 0);
}
class Developer : IEmployee
{
    private string name;
    public Developer(string name)
    {
        this.name = name;
    }
    public void ShowDetails(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "- Dev: " + name);
    }
}
class Manager : IEmployee
{
    private string name;
    public Manager(string name)
    {
        this.name = name;
    }
    public void ShowDetails(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "- HR: " + name);
    }
}
class Departament : IEmployee
{
    private string name;
    private List<IEmployee> employees = new List<IEmployee>();
    public Departament(string name)
    {
        this.name = name;
    }
    public void Add(IEmployee employee)
    {
        employees.Add(employee);
    }
    public void ShowDetails(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "- " + name + ":");
        foreach (var item in employees)
        {
            item.ShowDetails(indent + 2);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Departament company = new Departament("Company");
        Departament devdepart = new Departament("Development Departament");
        Departament frontendteam = new Departament("Frontend Team");
        Departament backendteam = new Departament("Backend Team");
        Departament QAteam = new Departament("QA Team");
        Departament HRdepart = new Departament("HR Departament");
        Developer Dev1 = new Developer("Barnabas Jackson");
        Developer Dev2 = new Developer("Frank Brown");
        Developer Dev3 = new Developer("Hardy Rivera");
        Developer Dev4 = new Developer("Job Adams");
        Developer Dev5 = new Developer("Martin Russell");
        Developer Dev6 = new Developer("Kevin Carter");
        Manager Maneger1 = new Manager("Ihor Henderson");

        frontendteam.Add(Dev1);
        frontendteam.Add(Dev2);
        frontendteam.Add(Dev3);
        backendteam.Add(Dev4);
        backendteam.Add(Dev5);
        QAteam.Add(Dev6);
        HRdepart.Add(Maneger1);

        devdepart.Add(frontendteam);
        devdepart.Add(backendteam);
        devdepart.Add(QAteam);

        company.Add(devdepart);
        company.Add(HRdepart);

        company.ShowDetails();
    }
}