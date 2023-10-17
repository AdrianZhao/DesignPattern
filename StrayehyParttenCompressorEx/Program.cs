using System.Globalization;
using System.Runtime.CompilerServices;
Client clientOne = new Client { Files = new List<string> { "catPcitures.png", "moreCatPictures.png"} };
Client clientTwo = new Client { Files = new List<string> { "pirateMusic.mp3", "pirateMusicAgain.mp3", "piratePoetry.txt" } };
FileCompressor compressor = new FileCompressor();
compressor.RunFileCompression(clientTwo, "rar");
compressor.RunFileCompression(clientTwo, "zip");
compressor.RunFileCompression(clientTwo, "tar");
public class FileCompressor
{
    private ICompressionBehaviour _compressionBehaviour;
    private void _compressFiles(Client client)
    {
        // delegate to the interface to run a method
        _compressionBehaviour.DoCompression(client);
    }
    private void _setCompressionBehaviour(string type)
    {
        switch (type)
        {
            case "zip":
                _compressionBehaviour = new CompressToZIP();
                break;
            case "rar":
                _compressionBehaviour = new CompressToRAR();
                break;
            default:
                throw new InvalidOperationException("Unknow compression format.");
        }
    }
    public void RunFileCompression(Client client, string type)
    {
        try
        {
            _setCompressionBehaviour(type);
            _compressFiles(client);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
public interface ICompressionBehaviour
{
    public void DoCompression(Client client);
}
public class CompressToRAR : ICompressionBehaviour
{
    public void DoCompression(Client client)
    {
        List<string> files = client.Files.ToList();
        foreach (string s in files)
        {
            Console.WriteLine($"Adding file {s} to RAR.");
        }
        Console.WriteLine($"RAR file created containing {files.Count} files.");
    }
}
public class CompressToZIP : ICompressionBehaviour
{
    public void DoCompression(Client client)
    {
        Console.WriteLine($"ZIP file created containing {client.Files.Count} files.");

    }
}
public class Client
{
    public List<string> Files { get; set; }
}