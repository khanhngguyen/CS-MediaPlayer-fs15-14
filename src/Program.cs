using Core.Entity;
using Infrastructure;
using Service.Files;

internal class Program
{
    private static void Main()
    {
        AudioFile audio1 = new AudioFile("Song 1");
        AudioFile audio2 = new AudioFile("Song 2");
        VideoFile video1 = new VideoFile("Video 1");
        // Console.WriteLine(audio1.FileFormat);
        // Console.WriteLine(video.FileFormat);
        // Playlist playlist = new Playlist("Playlist 1");

        FileRepository mediaPlayer = FileRepository.Instance;
        MediaFileService mediaFileService = new MediaFileService(mediaPlayer);
        mediaFileService.AddFile(audio1);
        mediaFileService.AddFile(audio2);
        mediaFileService.AddFile(video1);
        Console.WriteLine(mediaPlayer.GetAllFiles());
        Console.WriteLine(mediaPlayer.GetAllPlaylist());
    }
}