using System;
using System.ComponentModel;
using System.Reflection.Metadata;
interface IChatMediator
{
    void SendMessage(string message, User sender);
    void AddUser(User user);
}
class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();
    public void AddUser(User user) => users.Add(user);
    public void SendMessage(string message, User sender)
    {
        foreach(var user in users)
        {
            if (user != sender) user.Receive(message);
        }
    }
}
class User
{
    public string Name { get; }
    private IChatMediator chatMediator;
    public User(string name, IChatMediator chatMediator)
    {
        Name = name;
        this.chatMediator = chatMediator;
        chatMediator.AddUser(this);
    }
    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        chatMediator.SendMessage(message, this);

    }
    public void Receive(string message)
    {
        Console.WriteLine($"{Name} received a message: {message}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        IChatMediator chat = new ChatMediator();

        User user1 = new User("Ron", chat);
        User user2 = new User("Den", chat);
        User user3 = new User("John", chat);

        user1.Send("Hello everyone!");
        user3.Send("Hi!");
    }
}