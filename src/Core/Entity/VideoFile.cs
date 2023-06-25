namespace Core.Entity;
using Core.Interfaces;

class VideoFile : MediaFile, IVideo
{
    private string _format = String.Empty;

    public VideoFile(string name, string format = "mp4") : base(name)
    {
        FileName = name;
        _format = format;
    }

    public override string FileFormat
    {
        get { return _format; }
    }
    public override string ToString()
    {
        return this.FileName + _format;
    }
}