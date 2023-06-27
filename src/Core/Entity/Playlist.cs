using Core.ErrorHandler;
using Core.Observer;

namespace Core.Entity;

public class Playlist
{
    private string _name = String.Empty;
    private List<MediaFile> _fileList = new List<MediaFile>();
    public event EventHandler<PlaylistObserverArgs>? AddFileToListEvent = null;
    public event EventHandler<PlaylistObserverArgs>? DeleteFileFromListEvent = null;

    public string Name 
    {
        get { return _name; }
        set 
        {
            if (String.IsNullOrEmpty(value)) throw ExceptionHandler.PlaylistNameException();
            else _name = value;
        }
    }

    public bool AddFileToList(MediaFile file)
    {
        if (_fileList.Contains(file))
        {
            Console.WriteLine($"File {file.FileName} already exists in this Playlist");
            return false;
        }
        else 
        {
            _fileList.Add(file);
            this.NotifyAddFileToList(this);
            return true;
        }
    }
    public bool DeleteFileFromList(MediaFile file)
    {
        if (_fileList.Contains(file))
        {
            _fileList.Remove(file);
            this.NotifyDeleteFileFromList(this);
            return true;
        }
        else 
        {
            Console.WriteLine($"Can not delete, file {file.FileName} is not in this Playlist");
            return false;
        }
    }
    public string GetAllFilesInPlaylist()
    {
        if (_fileList.Count() == 0) return "There is no file in this Playlist";
        else
        {
            string text = $"All media files in Playlist {_name}: ";
            foreach (MediaFile item in _fileList)
            {
                text = text + $"\n{item.FileName}.{item.FileFormat}";
            }
            return text;
        }
    }
    public MediaFile? SearchFileInPlaylist(string name)
    {
        var existed = _fileList.Find(file => file.FileName.ToLower() == name.ToLower());
        if (existed != null)
        {
            Console.WriteLine($"Found {name} in Playlist {_name}");
            return existed;
        }
        else
        {
            Console.WriteLine($"No such file with name {name} in this Playlist");
            return null;
        }
    }
    public int CountFilesInPlaylist()
    {
        return _fileList.Count();
    }
    public override string ToString()
    {
        return "Playlist: " + _name;
    }

    public Playlist(string name)
    {
        Name = name;
    }
    public void NotifyAddFileToList(Playlist playlist)
    {
        var args = new PlaylistObserverArgs(playlist);
        if (AddFileToListEvent != null) AddFileToListEvent.Invoke(this, args);
    }
    public void NotifyDeleteFileFromList(Playlist playlist)
    {
        var args = new PlaylistObserverArgs(playlist);
        if (DeleteFileFromListEvent != null) DeleteFileFromListEvent.Invoke(this, args);
    }

    ~Playlist()
    {
        Console.WriteLine($"Playlist {_name} is disposed");
    }
}