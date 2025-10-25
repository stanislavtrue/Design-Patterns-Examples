using System;
using System.Xml.Serialization;

namespace Visitor;

interface IVisitor
{
    void Visit(Monkey monkey);
    void Visit(Elephant elephant);
    void Visit(Lion lion);
}
interface IAnimal
{
    void Accept(IVisitor visitor);
}

class Monkey : IAnimal
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

class Elephant : IAnimal
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

class Lion : IAnimal
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

class FeedingVisitor : IVisitor
{
    public string value;
    public void Visit(Monkey monkey) => value = "I fed the monkey bananas!";
    public void Visit(Elephant elephant) => value = "I fed the elephant fruit!";
    public void Visit(Lion lion) => value = "I fed the lion meat!";
}
class Program
{
    static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>() { new Monkey(), new Elephant(), new Lion() };
        foreach (IAnimal animal in animals)
        {
            FeedingVisitor visitor = new FeedingVisitor();
            animal.Accept(visitor);
            Console.WriteLine(visitor.value);
        }
    }
}