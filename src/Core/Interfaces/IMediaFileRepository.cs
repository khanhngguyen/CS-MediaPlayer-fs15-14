using Core.Entity;
namespace Core.Interfaces;

public interface IMediaFileRepository
{
    public bool AddFile(MediaFile file);
    public bool DeleteFile(MediaFile file);
    public string GetAllFiles();
    public MediaFile? SearchFile(string name);
    public Playlist CreatePlaylist(string name);
    public bool DeletePlaylist(string name);
    public string GetAllPlaylist();
    public Playlist? SearchPlaylist(string name);
    
}