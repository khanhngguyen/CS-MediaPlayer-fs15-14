using Core.Entity;
namespace Core.Factory;

class VideoFileFactory : MediaFileFactory
{
    protected override MediaFile MakeFile(string name)
    {
        MediaFile file = new VideoFile(name);
        return file;
    }
}