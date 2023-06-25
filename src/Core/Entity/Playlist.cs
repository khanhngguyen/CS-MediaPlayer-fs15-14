namespace Core.Entity;

class Playlist
{
    private string _name = String.Empty;
    private readonly List<MediaFile> _fileList = new List<MediaFile>();

    public string Name 
    {
        get { return _name; }
        set 
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentException("Playlist name can not be empty");
            else _name = value;
        }
    }

    public Playlist(string name)
    {
        Name = name;
    }
}