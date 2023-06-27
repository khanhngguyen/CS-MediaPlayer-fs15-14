using Core.Entity;
namespace Core.Observer;

public class PlaylistObserverArgs
{
    public Playlist Playlist { get; set; }

    public PlaylistObserverArgs(Playlist playlist)
    {
        Playlist = playlist;
    }
}