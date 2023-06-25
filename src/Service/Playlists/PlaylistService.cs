using Core.Entity;
using Core.Interfaces;
namespace Service.Playlists;

class PlaylistService : IPlaylistService
{
    private IMediaFileRepository _fileRepository;

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
        return _fileRepository.CreatePlaylist(name);
    }
    public bool DeletePlaylist(string name)
    {
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
}