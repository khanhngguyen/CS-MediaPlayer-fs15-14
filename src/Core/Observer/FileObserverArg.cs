using Core.Entity;
namespace Core.Observer;

public class FileObserverArgs
{
    public MediaFile File { get; set; }

    public FileObserverArgs(MediaFile file)
    {
        File = file;
    }
}