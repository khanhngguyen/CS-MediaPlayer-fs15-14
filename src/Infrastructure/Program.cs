using Controller;
using Core.Entity;
using Core.Factory;
using Infrastructure;
using Service.Files;
using Service.Playlists;

internal class Program
{
    private static void Main()
    {
        // AudioFile audio1 = new AudioFile("Song 1");
        // AudioFile audio2 = new AudioFile("Song 2");
        // VideoFile video1 = new VideoFile("Video 1");
        MediaFile audio1 = new AudioFileFactory().CreateFile("Song 1");
        MediaFile audio2 = new AudioFileFactory().CreateFile("Song 2");
        MediaFile video1 = new VideoFileFactory().CreateFile("Video 1");
        MediaFile video2 = new VideoFileFactory().CreateFile("Video 2");

        // Console.WriteLine(audio1.GetType().ToString());
        // Console.WriteLine(video1.GetType().ToString());
        // Console.WriteLine(audio1.FileFormat);
        // Console.WriteLine(video.FileFormat);
        // Playlist playlist = new Playlist("Playlist 1");

        // MediaFileRepository mediaPlayer = MediaFileRepository.Instance;
        // MediaFileService mediaFileService = new MediaFileService(mediaPlayer);
        // PlaylistService playlistService = new PlaylistService(mediaPlayer);
        // MediaFileController fileController = new MediaFileController(mediaFileService);
        // PlaylistController playlistController = new PlaylistController(playlistService);

        var mediaPlayer = MediaFileRepository.Instance;
        var mediaFileService = new MediaFileService(mediaPlayer);
        var playlistService = new PlaylistService(mediaPlayer);
        var fileController = new MediaFileController(mediaFileService);
        var playlistController = new PlaylistController(playlistService);
        
        var user = User.Instance;
        mediaFileService.AddFileEvent += user.HandleAddFileEvent;
        mediaFileService.DeleteFileEvent += user.HandleDeleteFileEvent;
        playlistService.CreatePlaylistEvent += user.HandleCreatePlaylistEvent;
        playlistService.DeletePlaylistEvent += user.HandleDeletePlaylistEvent;

        fileController.AddFile(audio1);
        fileController.AddFile(audio2);
        fileController.AddFile(video1);
        fileController.AddFile(video2);
        fileController.DeleteFile(video2);
        var playlist = playlistController.CreatePlaylist("Pop songs");
        playlist.AddFileToListEvent += user.HandleAddFileToListEvent;
        playlist.DeleteFileFromListEvent += user.HandleDeleteFileFromListEvent;

        // playlistController.DeletePlaylist("pop songs");
        Console.WriteLine(mediaPlayer.GetAllFiles());
        Console.WriteLine(mediaPlayer.GetAllPlaylist());
        playlist.AddFileToList(audio1);
        playlist.AddFileToList(audio2);
        // playlist.DeleteFileFromList(audio2);
        Console.WriteLine(playlist.GetAllFilesInPlaylist());
        // Console.WriteLine(playlist.SearchFileInPlaylist("song 1"));
        // playlistController.Play(playlist);
        // fileController.Play(video1);
        // fileController.Pause(video1);
        // fileController.Stop(video1);
        // Console.WriteLine(fileController.SearchFile("Video"));
        // playlistController.DeletePlaylist("Favorites");
        // playlistController.DeletePlaylist("Pop songs");
        // Console.WriteLine(playlistController.GetAllPlaylist());
        /* bool isPlaying = true;
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
        } */
    }
}