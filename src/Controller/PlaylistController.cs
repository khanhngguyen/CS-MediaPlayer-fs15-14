using Service.Playlists;
namespace Controller;

class PlaylistController
{
    private IPlaylistService _playlistService;

    public PlaylistController(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }
}