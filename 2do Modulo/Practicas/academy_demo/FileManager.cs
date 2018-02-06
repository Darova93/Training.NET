namespace academy_demo
{
    public interface FileManager

    {

        bool CanRead(string path);

        string Read(string path);

    }

}