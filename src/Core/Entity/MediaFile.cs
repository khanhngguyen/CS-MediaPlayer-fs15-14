using Core.ErrorHandler;
namespace Core.Entity;

public abstract class MediaFile 
{
    private string _fileName = String.Empty;
    private string _format = String.Empty;

    public string FileName
    {
        get { return _fileName; }
        set
        {
            if (String.IsNullOrEmpty(value)) throw ExceptionHandler.FileNameException();
            else _fileName = value;
        }
    }
    
    public abstract string GetFileType();
    public virtual string FileFormat
    {
        get { return _format; }
    }
    public override string ToString()
    {
        return _fileName;
    }

    public MediaFile(string name)
    {
        FileName = name;
    }

    ~MediaFile()
    {
        Console.WriteLine($"Media file {_fileName} is disposed");
    }
}
