namespace Core.Entity;
using Core.Interfaces;

class AudioFile : MediaFile, IAudio
{
    public AudioFile(string name, string format = "mp3") : base(name)
    {
        FileName = name;
        FileFormat = format;
    }

    public string FileFormat { get; }
}
