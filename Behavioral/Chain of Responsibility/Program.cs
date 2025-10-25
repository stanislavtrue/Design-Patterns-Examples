using System;
abstract class Approver
{
    protected Approver? NextApprover;
    public void SetNext(Approver approver)
    {
        NextApprover = approver;
    }
    public abstract void ProcessRequest(SalaryRequest request);
}
class SalaryRequest
{
    public string EmployeeName { get; }
    public double Amount { get; }
    public SalaryRequest(string name, double amount)
    {
        EmployeeName = name;
        Amount = amount;
    }
}
class Manager : Approver
{
    public override void ProcessRequest(SalaryRequest request)
    {
        if (request.Amount <= 1000)
        {
            Console.WriteLine($"Manager approved {request.Amount}$ raise for {request.EmployeeName}");
        }
        else if (NextApprover != null)
        {
            Console.WriteLine($"Manager passed request further...");
            NextApprover.ProcessRequest(request);
        }
    }
}
class HeadDepartament : Approver
{
    public override void ProcessRequest(SalaryRequest request)
    {
        if (request.Amount <= 5000)
        {
            Console.WriteLine($"Head of Departament approved {request.Amount}$ raise for {request.EmployeeName}");
        }
        else if (NextApprover != null)
        {
            Console.WriteLine($"Head of Departament passed request further...");
            NextApprover.ProcessRequest(request);
        }
    }
}
class Director : Approver
{
    public override void ProcessRequest(SalaryRequest request)
    {
        Console.WriteLine($"Director approved {request.Amount}$ raise for {request.EmployeeName}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager();
        HeadDepartament headdepartament = new HeadDepartament();
        Director director = new Director();
        manager.SetNext(headdepartament);
        headdepartament.SetNext(director);

        var req1 = new SalaryRequest("Rob", 600);
        var req2 = new SalaryRequest("Tom", 8500);
        manager.ProcessRequest(req1);
        Console.WriteLine();
        manager.ProcessRequest(req2);
    }
}