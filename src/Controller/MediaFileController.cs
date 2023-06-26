using Core.Entity;
using Service.Files;
namespace Controller;

class MediaFileController
{
    private IMediaFileService _mediaFileService;
    public MediaFileController(IMediaFileService mediaFileService)
    {
        _mediaFileService = mediaFileService;
    }

    public void Play(MediaFile file)
    {
        _mediaFileService.Play(file);
    }
    public void Pause(MediaFile file)
    {
        _mediaFileService.Pause(file);
    }
    public void Stop(MediaFile file)
    {
        _mediaFileService.Stop(file);
    }
    public bool AddFile(MediaFile file)
    {
        return _mediaFileService.AddFile(file);
    }
    public bool DeleteFile(MediaFile file)
    {
        return _mediaFileService.DeleteFile(file);
    }
    public string GetAllFiles()
    {
        return _mediaFileService.GetAllFiles();
    }
    public MediaFile? SearchFile(string name)
    {
        return _mediaFileService.SearchFile(name);
    }

    ~MediaFileController()
    {
        Console.WriteLine("MediaController is disposed");
    }
}