using Core.Entity;
using Core.Interfaces;
using Core.Observer;

namespace Service.Files;

class MediaFileService : IMediaFileService
{
    private IMediaFileRepository _fileRepository;
    public event EventHandler<FileObserverArgs>? AddFileEvent = null;
    public event EventHandler<FileObserverArgs>? DeleteFileEvent = null;

    public MediaFileService(IMediaFileRepository repository)
    {
        _fileRepository = repository;
    }

    public void Play(MediaFile file)
    {
        var existed = _fileRepository.SearchFile(file.FileName);
        if (existed != null) Console.WriteLine($"Playing {file.FileName}");
        else Console.WriteLine($"Can not play, file {file.ToString()} does not exist");
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
        this.NotifyAddFile(file);
        return _fileRepository.AddFile(file);
    }
    public bool DeleteFile(MediaFile file)
    {
        this.NotifyDeleteFile(file);
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
    public void NotifyAddFile(MediaFile file)
    {
        var args = new FileObserverArgs(file);
        if (AddFileEvent != null) AddFileEvent.Invoke(this, args);
    }
    public void NotifyDeleteFile(MediaFile file)
    {
        var args = new FileObserverArgs(file);
        if (DeleteFileEvent != null) DeleteFileEvent.Invoke(this, args);
    }

    ~MediaFileService()
    {
        Console.WriteLine("MediaService is disposed");
    }
}
