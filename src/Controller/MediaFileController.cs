using Service.Files;
namespace Controller;

class MediaFileController
{
    private IMediaFileService _mediaFileService;
    public MediaFileController(IMediaFileService mediaFileService)
    {
        _mediaFileService = mediaFileService;
    }
}