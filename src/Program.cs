using Controller;
using Core.Entity;
using Infrastructure;
using Service.Files;
using Service.Playlists;

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

        // FileRepository mediaPlayer = FileRepository.Instance;
        // MediaFileService mediaFileService = new MediaFileService(mediaPlayer);
        // PlaylistService playlistService = new PlaylistService(mediaPlayer);
        // MediaFileController fileController = new MediaFileController(mediaFileService);
        // PlaylistController playlistController = new PlaylistController(playlistService);

        var mediaPlayer = FileRepository.Instance;
        var mediaFileService = new MediaFileService(mediaPlayer);
        var playlistService = new PlaylistService(mediaPlayer);
        var fileController = new MediaFileController(mediaFileService);
        var playlistController = new PlaylistController(playlistService);

        fileController.AddFile(audio1);
        fileController.AddFile(audio2);
        fileController.AddFile(video1);
        var playlist = playlistController.CreatePlaylist("Pop songs");
        Console.WriteLine(mediaPlayer.GetAllFiles());
        Console.WriteLine(mediaPlayer.GetAllPlaylist());
        playlist.AddFileToList(audio1);
        playlist.AddFileToList(audio2);
        // Console.WriteLine(playlist.GetAllFilesInPlaylist());
        // Console.WriteLine(playlist.SearchFileInPlaylist("song 1"));
        // playlistController.Play(playlist);
        // fileController.Play(video1);
        // fileController.Pause(video1);
        // fileController.Stop(video1);
        // Console.WriteLine(fileController.SearchFile("Video"));
        // playlistController.DeletePlaylist("Favorites");
        // playlistController.DeletePlaylist("Pop songs");
        // Console.WriteLine(playlistController.GetAllPlaylist());
        bool isPlaying = true;
        while (isPlaying)
        {
            Console.WriteLine("input command: ");
            var command = Console.ReadLine();
            switch (command)
            {
                case "play":
                playlistController.Play(playlist);
                break;
                case "stop":
                Console.WriteLine("stop playing");
                isPlaying = false;
                break;
                default:
                Console.WriteLine("Invalid input, retry: ");
                break;
            }
        }
    }
}