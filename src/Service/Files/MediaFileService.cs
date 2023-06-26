using Core.Entity;
using Core.Interfaces;
namespace Service.Files;

class MediaFileService : IMediaFileService
{
    private IMediaFileRepository _fileRepository;

    public MediaFileService(IMediaFileRepository repository)
    {
        _fileRepository = repository;
    }

    public void Play(MediaFile file)
    {
        Console.WriteLine($"Playing {file.FileName}");
    }
    public void Pause(MediaFile file)
    {
        Console.WriteLine($"{file.FileName} has been paused");
    }
    public void Stop(MediaFile file)
    {
        Console.WriteLine($"Stop playing {file.FileName}");
    }
    public bool AddFile(MediaFile file)
    {
        return _fileRepository.AddFile(file);
    }
    public bool DeleteFile(MediaFile file)
    {
        return _fileRepository.DeleteFile(file);
    }
    public string GetAllFiles()
    {
        return _fileRepository.GetAllFiles();
    }
    public MediaFile? SearchFile(string name)
    {
        return _fileRepository.SearchFile(name);
    }

    ~MediaFileService()
    {
        Console.WriteLine("MediaService is disposed");
    }
}
