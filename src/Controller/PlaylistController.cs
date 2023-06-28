using Core.Entity;
using Service.Playlists;
namespace Controller;

class PlaylistController
{
    private IPlaylistService _playlistService;

    public PlaylistController(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    public void Play(Playlist playlist)
    {
        _playlistService.Play(playlist);
    }
    public void Stop(Playlist playlist)
    {
        _playlistService.Stop(playlist);
    }
    public Playlist CreatePlaylist(string name)
    {
        return _playlistService.CreatePlaylist(name);
    }
    public bool DeletePlaylist(string name)
    {
        return _playlistService.DeletePlaylist(name);
    }
    public string GetAllPlaylist()
    {
        return _playlistService.GetAllPlaylist();
    }
    public Playlist? SearchPlaylist(string name)
    {
        return _playlistService.SearchPlaylist(name);
    }
    public string GetAllFilesInPlaylist(Playlist playlist)
    {
        return _playlistService.GetAllFilesInPlaylist(playlist);
    }

    ~PlaylistController()
    {
        Console.WriteLine("PlaylistController is disposed");
    }
}