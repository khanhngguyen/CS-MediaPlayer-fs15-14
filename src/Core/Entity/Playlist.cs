namespace Core.Entity;

public class Playlist
{
    private string _name = String.Empty;
    private List<MediaFile> _fileList = new List<MediaFile>();

    public string Name 
    {
        get { return _name; }
        set 
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentException("Playlist name can not be empty");
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
            return true;
        }
    }
    public bool DeleteFileFromList(MediaFile file)
    {
        if (_fileList.Contains(file))
        {
            _fileList.Remove(file);
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
    public override string ToString()
    {
        return "Playlist: " + _name;
    }

    public Playlist(string name)
    {
        Name = name;
    }
}