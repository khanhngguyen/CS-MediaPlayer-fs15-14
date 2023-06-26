namespace Core.ErrorHandler;

class ExceptionHandler : Exception
{
    private string _message;

    public ExceptionHandler(string message)
    {
        _message = message;
    }

    public override string ToString()
    {
        return _message;
    }
    public static ExceptionHandler FileNameException()
    {
        return new ExceptionHandler("File name can not be empty");
    }
    public static ExceptionHandler PlaylistNameException()
    {
        return new ExceptionHandler("Playlist name can not be empty");
    }
}