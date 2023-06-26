namespace Core.Entity;
using Core.Interfaces;

class AudioFile : MediaFile, IAudio
{
    private string _format = String.Empty;

    public AudioFile(string name, string format = "mp3") : base(name)
    {
        FileName = name;
        _format = format;
    }

    public override string GetFileType()
    {
        return $"file type: audio, format: {_format}";
    }
    public override string FileFormat 
    {
        get { return _format; }
    }
    public override string ToString()
    {
        return this.FileName + "." + _format;
    }

    ~AudioFile()
    {
        Console.WriteLine($"Audio file {FileName} is disposed");
    }
}
