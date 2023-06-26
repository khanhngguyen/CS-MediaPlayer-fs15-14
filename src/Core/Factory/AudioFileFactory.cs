using Core.Entity;
namespace Core.Factory;

class AudioFileFactory : MediaFileFactory
{
    protected override MediaFile MakeFile(string name)
    {
        MediaFile file = new AudioFile(name);
        return file;
    }
}