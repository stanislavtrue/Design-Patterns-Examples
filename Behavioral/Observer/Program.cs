using System;
namespace Observer;

interface ISubscriber
{
    void Update(string video);
}

interface IChannel
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void Notify(string video);
}

class YouTubeChannel(string name) : IChannel
{
    private List<ISubscriber> subscribers = new List<ISubscriber>();
    public string Name { get; } = name;

    public void Subscribe(ISubscriber subscriber) => subscribers.Add(subscriber);
    public void Unsubscribe(ISubscriber subscriber) => subscribers.Remove(subscriber);

    public void Notify(string video)
    {
        Console.WriteLine($"{Name} published new video: {video}");
        foreach (var subscriber in subscribers)
        {
            subscriber.Update(video);
        }
    }

    public void UploadVideo(string title) => Notify(title);
}

class User(string Name) : ISubscriber
{
    private string Name = Name;
    public void Update(string video) => Console.WriteLine($"{Name} received a notification about a new video: {video}");
}
class Program
{
    static void Main(string[] args)
    {
        YouTubeChannel channel = new YouTubeChannel("ChannelC#");
        User user1 = new User("George");
        User user2 = new User("Den");

        channel.Subscribe(user1);
        channel.Subscribe(user2);

        channel.UploadVideo("What is OOP?");
        Console.WriteLine();
        channel.UploadVideo("Observer pattern!");
        Console.WriteLine();
        channel.UploadVideo("The last video on the channel.");
    }
}