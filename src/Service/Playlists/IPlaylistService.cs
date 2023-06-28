using Core.Entity;
namespace Service.Playlists;

public interface IPlaylistService
{
    public void Play(Playlist playlist);
    public void Stop(Playlist playlist);
    public Playlist CreatePlaylist(string name);
    public bool DeletePlaylist(string name);
    public string GetAllPlaylist();
    public Playlist? SearchPlaylist(string name);
    public string GetAllFilesInPlaylist(Playlist playlist);
}