using System;
interface IAudioPlayer
{
    string PlayAudio();
}
class OldAudioPlayer
{
    public string Mp3Player()
    {
        return "Sounds mp3.";
    }
}
class Adapter : IAudioPlayer
{
    private readonly OldAudioPlayer _oldplayer;
    public Adapter(OldAudioPlayer oldplayer)
    {
        this._oldplayer = oldplayer;
    }
    public string PlayAudio()
    {
        return $"{this._oldplayer.Mp3Player()}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        OldAudioPlayer oldAudioPlayer = new OldAudioPlayer(); 
        IAudioPlayer audioplayer = new Adapter(oldAudioPlayer);
        Console.WriteLine(audioplayer.PlayAudio());
    }
}