using Core.Entity;

internal class Program
{
    private static void Main()
    {
        AudioFile audio = new AudioFile("song 1");
        VideoFile video = new VideoFile("video 1");
        Console.WriteLine(audio.FileFormat);
        Console.WriteLine(video.FileFormat);
        Playlist playlist = new Playlist("Playlist 1");
    }
}