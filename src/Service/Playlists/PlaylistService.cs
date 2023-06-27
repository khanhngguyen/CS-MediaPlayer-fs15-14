using Core.Entity;
using Core.Interfaces;
using Core.Observer;

namespace Service.Playlists;

class PlaylistService : IPlaylistService
{
    private IMediaFileRepository _fileRepository;
    public event EventHandler<PlaylistObserverArgs>? CreatePlaylistEvent = null;
    public event EventHandler<PlaylistObserverArgs>? DeletePlaylistEvent = null;

    public PlaylistService(IMediaFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public void Play(Playlist playlist)
    {
        Console.WriteLine($"Play all media files in Playlist: {playlist.Name}");
        Console.WriteLine(playlist.GetAllFilesInPlaylist());
    }
    public Playlist CreatePlaylist(string name)
    {
        Playlist playlist = _fileRepository.CreatePlaylist(name);
        this.NotifyCreatePlaylist(playlist);
        return playlist;
        // return _fileRepository.CreatePlaylist(name);
    }
    public bool DeletePlaylist(string name)
    {
        var existed = _fileRepository.SearchPlaylist(name);
        if (existed != null)
        {
            this.NotifyDeletePlaylist(existed);
        }
        return _fileRepository.DeletePlaylist(name);
    }
    public string GetAllPlaylist()
    {
        return _fileRepository.GetAllPlaylist();
    }
    public Playlist? SearchPlaylist(string name)
    {
        return _fileRepository.SearchPlaylist(name);
    }
    public void NotifyCreatePlaylist(Playlist playlist)
    {
        var args = new PlaylistObserverArgs(playlist);
        if (CreatePlaylistEvent != null) CreatePlaylistEvent.Invoke(this, args);
    }
    public void NotifyDeletePlaylist(Playlist playlist)
    {
        var args = new PlaylistObserverArgs(playlist);
        if (DeletePlaylistEvent != null) DeletePlaylistEvent.Invoke(this, args);
    }

    ~PlaylistService()
    {
        {
        Console.WriteLine("PlaylistService is disposed");
    }
    }
}