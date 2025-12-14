using System;

interface IVideo
{
    void Play();
}

class RealVideo : IVideo
{
    public void Play()
    {
        Console.WriteLine("Playing the original video...");
    }
}

class ProxyVideo : IVideo
{
    private RealVideo _realvideo;
    private string _filename;
    
    public ProxyVideo(string filename)
    {
        this._filename = filename;
    }
    
    public void Play()
    {
        if (_realvideo == null)
        {
            Console.WriteLine("Loading video from disk...");
            _realvideo = new RealVideo();
        }
        _realvideo.Play();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IVideo video = new ProxyVideo("Video.mp4");
        Console.WriteLine("Video object created, but not loaded yet.\n");
        video.Play();
        video.Play();
    }
}
