namespace Core.Entity;
using Core.Interfaces;

class VideoFile : MediaFile, IVideo
{
    public VideoFile(string name, string format = "mp4") : base(name)
    {
        FileName = name;
        FileFormat = format;
    }

    public string FileFormat { get; }
}