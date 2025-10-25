using System;
interface IIterator<T>
{
    bool MoveNext();
    T next();
}
interface IPlaylist
{
    IIterator<Song> CreateIterator();
}
class Song
{
    public string Name { get; }
    public string Singer { get; }
    public Song (string singer, string name)
    {
        Singer = singer;        
        Name = name;
    }
}
class Playlist : IPlaylist
{
    private List<Song> songs = new List<Song>();
    public void AddSong(Song song) => songs.Add(song);
    public IIterator<Song> CreateIterator()
    {
        return new PlaylistIterator(songs);
    }
}
class PlaylistIterator : IIterator<Song>
{
    private readonly List<Song> _songs;
    private int position;
    public PlaylistIterator(List<Song> songs) => _songs = songs;
    public bool MoveNext()
    {
        return position < _songs.Count;
    }
    public Song next()
    {
        return _songs[position++];
    }
}
class Program
{
    static void Main(string[] args)
    {
        Playlist playlist = new Playlist();
        playlist.AddSong(new Song("Twisted Sister", "I Wanna Rock"));
        playlist.AddSong(new Song("Twisted Sister", "Never Say Never"));
        playlist.AddSong(new Song("AC-DC", "T.N.T."));

        IIterator<Song> iterator = playlist.CreateIterator();

        Console.WriteLine("Playlist songs:\n");
        while (iterator.MoveNext())
        {
            var song = iterator.next();
            Console.WriteLine($"{song.Singer} - {song.Name}");
        }
    }
}