using Core.Entity;
namespace Core.Factory;

abstract class MediaFileFactory
{
    protected abstract MediaFile MakeFile(string name);
    public MediaFile CreateFile(string name)
    {
        return this.MakeFile(name);
    }
}