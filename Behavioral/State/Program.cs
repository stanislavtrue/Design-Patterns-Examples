using System;
namespace State;

interface ITrafficlightsState
{
    void Show();
    void Next(TrafficLight nextLight);
}

class RedLight : ITrafficlightsState
{
    public void Show() => Console.WriteLine("Red Light.");
    public void Next(TrafficLight nextLight) => nextLight.SetState(new GreenLight());
}

class GreenLight : ITrafficlightsState
{
    public void Show() => Console.WriteLine("Green Light.");
    public void Next(TrafficLight nextLight) => nextLight.SetState(new YellowLight());
}

class YellowLight : ITrafficlightsState
{
    public void Show() => Console.WriteLine("Yellow Light.");
    public void Next(TrafficLight nextLight) => nextLight.SetState(new RedLight());
}

class TrafficLight
{
    private ITrafficlightsState _state;

    public TrafficLight(ITrafficlightsState startstate)
    {
        _state = startstate;
    }

    public void SetState(ITrafficlightsState state)
    {
        _state = state;
    }

    public void Show()
    {
        _state.Show();
    }

    public void NextLight()
    {
        _state.Next(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TrafficLight trafficLight = new TrafficLight(new GreenLight());
        while (true)
        {   
            trafficLight.Show();
            trafficLight.NextLight();
            Thread.Sleep(1000);
        }
    }
}
