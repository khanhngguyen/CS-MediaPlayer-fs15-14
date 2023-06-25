namespace Core.Entity;

abstract class MediaFile 
{
    private string _fileName = String.Empty;

    public string FileName
    {
        get { return _fileName; }
        set
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentException("File name can not be empty");
            else _fileName = value;
        }
    }

    public MediaFile(string name)
    {
        FileName = name;
    }
}
