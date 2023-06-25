using Core.Entity;
using Core.Interfaces;
namespace Infrastructure;

public sealed class FileRepository : IMediaFileRepository
{
    private List<MediaFile> _fileList = new List<MediaFile>();
    private List<Playlist> _playlistList = new List<Playlist>();
    private static readonly Lazy<FileRepository> _lazy = new Lazy<FileRepository>(() => new FileRepository());

    public FileRepository()
    {
        
    }

    public static FileRepository Instance 
    {
        get { return _lazy.Value; }
    }

    public bool AddFile(MediaFile file)
    {
        if (_fileList.Contains(file))
        {
            Console.WriteLine($"Media file {file.FileName} already exists in library");
            return false;
        }
        else 
        {
            _fileList.Add(file);
            return true;
        }
    }
    public bool DeleteFile(MediaFile file)
    {
        if (_fileList.Contains(file))
        {
            _fileList.Remove(file);
            return true;
        }
        else 
        {
            Console.WriteLine($"Can not delete, file {file.FileName} is not in library");
            return false;
        }
    }
    public string GetAllFiles()
    {
        if (_fileList.Count() == 0) return "There is no file in library";
        else
        {
            string text = "All media files: ";
            foreach (MediaFile item in _fileList)
            {
                text = text + $"\n{item.FileName}.{item.FileFormat}";
            }
            return text;
        }
    }
    public MediaFile? SearchFile(string name)
    {
        var existed = _fileList.Find(file => file.FileName.ToLower() == name.ToLower());
        if (existed != null) return existed;
        else
        {
            Console.WriteLine($"No such file with name {name} in library");
            return null;
        }
    }
    public Playlist CreatePlaylist(string name)
    {
        Playlist playlist = new Playlist(name);
        if (_playlistList.Contains(playlist))
        {
            Console.WriteLine($"Playlist {playlist.Name} already exists in library");
        }
        else 
        {
            _playlistList.Add(playlist);
        }
        return playlist;
    }
    public bool DeletePlaylist(string name)
    {
        var existed = _playlistList.Find(playlist => playlist.Name.ToLower() == name.ToLower());
        if (existed != null)
        {
            _playlistList.Remove(existed);
            return true;
        }
        else 
        {
            Console.WriteLine($"Can not delete, Playlist {name} is not in library");
            return false;
        }
    }
    public string GetAllPlaylist()
    {
        if (_playlistList.Count() == 0) return "There is no Playlist in library";
        else 
        {
            string text = "All Playlist: ";
            foreach (Playlist item in _playlistList)
            {
                text = text + $"\n{item.Name}";
            }
            return text;
        }
    }
    public Playlist? SearchPlaylist(string name)
    {
        var existed = _playlistList.Find(playlist => playlist.Name.ToLower() == name.ToLower());
        if (existed != null) return existed;
        else
        {
            Console.WriteLine($"Can not find Playlist with name {name}");
            return null;
        }
    }
}