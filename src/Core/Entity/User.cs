using Core.ErrorHandler;
using Core.Observer;
namespace Core.Entity;

public sealed class User
{
    private static readonly Lazy<User> _lazy = new Lazy<User>(() => new User());

    public User() { }

    public static User Instance
    {
        get { return _lazy.Value; }
    }
    public void HandleAddFileEvent(object? sender, FileObserverArgs e)
    {
        Console.WriteLine($"--{e.File.FileName}.{e.File.FileFormat} is added to Media Player--");
    }
    public void HandleDeleteFileEvent(object? sender, FileObserverArgs e)
    {
        Console.WriteLine($"--{e.File.FileName}.{e.File.FileFormat} is deleted from Media Player--");
    }
    public void HandleCreatePlaylistEvent(object? sender, PlaylistObserverArgs e)
    {
        Console.WriteLine($"--New {e.Playlist} is created--");
    }
    public void HandleDeletePlaylistEvent(object? sender, PlaylistObserverArgs e)
    {
        Console.WriteLine($"--{e.Playlist} is deleted from Media Player--");
    }
    public void HandleAddFileToListEvent(object? sender, PlaylistObserverArgs e)
    {
        Console.WriteLine($"--A new file is added to {e.Playlist}--");
        Console.WriteLine($"--Number of files in {e.Playlist}: {e.Playlist.CountFilesInPlaylist()}--");
    }
    public void HandleDeleteFileFromListEvent(object? sender, PlaylistObserverArgs e)
    {
        Console.WriteLine($"--A file has been deleted from {e.Playlist}--");
        Console.WriteLine($"--Number of files in {e.Playlist}: {e.Playlist.CountFilesInPlaylist()}--");
    }
}