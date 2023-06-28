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
        Console.WriteLine("\nCreate audio & video files using factory methods:");
        MediaFile audio1 = new AudioFileFactory().CreateFile("Hype Boy - New Jeans");
        MediaFile audio2 = new AudioFileFactory().CreateFile("LEFT RIGHT - XG");
        MediaFile audio3 = new AudioFileFactory().CreateFile("Back 2 U - NCT 127");
        MediaFile video1 = new VideoFileFactory().CreateFile("Attention MV - New Jeans");
        MediaFile video2 = new VideoFileFactory().CreateFile("Flower MV - Jisoo BLACKPINK");
        Console.WriteLine("{0}, {1}, {2}, {3}", audio1.ToString(), audio2.ToString(), video1.ToString(), video2.ToString());

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

        Console.WriteLine("\nSet up a single user, a Media Player as a single Media File Repository, controller & service for Media Player");
        var mediaPlayer = MediaFileRepository.Instance;
        var mediaFileService = new MediaFileService(mediaPlayer);
        var playlistService = new PlaylistService(mediaPlayer);
        var fileController = new MediaFileController(mediaFileService);
        var playlistController = new PlaylistController(playlistService);
        
        Console.WriteLine("\nSet user as an observer of Media Player, user will receive notification when files are added/deleted inside Media Player and specific Playlist");
        var user = User.Instance;
        mediaFileService.AddFileEvent += user.HandleAddFileEvent;
        mediaFileService.DeleteFileEvent += user.HandleDeleteFileEvent;
        playlistService.CreatePlaylistEvent += user.HandleCreatePlaylistEvent;
        playlistService.DeletePlaylistEvent += user.HandleDeletePlaylistEvent;

        Console.WriteLine("\nAdding files into Media Player");
        fileController.AddFile(audio1);
        fileController.AddFile(audio2);
        fileController.AddFile(audio3);
        fileController.AddFile(video1);
        fileController.AddFile(video2);
        fileController.DeleteFile(video2);
        
        Console.WriteLine("\nCreate Playlists");
        var playlist = playlistController.CreatePlaylist("New Jeans");
        var playlist2 = playlistController.CreatePlaylist("Rock songs");

        Console.WriteLine("\nMedia Player info so far:");
        Console.WriteLine(mediaPlayer.GetAllFiles());
        Console.WriteLine(mediaPlayer.GetAllPlaylist());
        Console.WriteLine(playlist.GetAllFilesInPlaylist());
        Console.WriteLine(playlist2.GetAllFilesInPlaylist());

        Console.WriteLine("\nUser can interact/control each media file individually:");
        fileController.Play(audio3);
        fileController.Pause(audio3);
        fileController.Stop(audio3);
        fileController.Play(video1);
        fileController.Stop(video1);
        fileController.Play(video2);

        Console.WriteLine("\nOr user can add/delete files into a Playlist and interact/control that Playlist");
        playlist.AddFileToListEvent += user.HandleAddFileToListEvent;
        playlist.DeleteFileFromListEvent += user.HandleDeleteFileFromListEvent;        
        playlist.AddFileToList(audio1);
        playlist.AddFileToList(video1);

        Console.WriteLine("\nWhen user choose to play a Playlist, user can then control it using CLI.");
        playlistController.Play(playlist);
        while (playlist.IsPlaying)
        {
            Console.WriteLine("Enter \"play\", \"stop\", \"all files\" to control Playlist");
            Console.WriteLine("Input command: ");
            var command = Console.ReadLine();
            switch (command)
            {
                case "play":
                playlistController.Play(playlist);
                break;
                case "stop":
                playlistController.Stop(playlist);
                break;
                case "all files":
                Console.WriteLine(playlistController.GetAllFilesInPlaylist(playlist));
                break;
                default:
                Console.WriteLine("Invalid input, retry: ");
                break;
            }
        }

        // playlistController.Play(playlist);
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
    }
}