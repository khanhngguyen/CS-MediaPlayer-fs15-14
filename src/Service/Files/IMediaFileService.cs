namespace Service.Files;
using Core.Entity;

public interface IMediaFileService
{
    public void Play(MediaFile file);
    public void Pause(MediaFile file);
    public void Stop(MediaFile file);
    public bool AddFile(MediaFile file);
    public bool DeleteFile(MediaFile file);
    public string GetAllFiles();
    public MediaFile? SearchFile(string name);
}