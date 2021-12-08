namespace aoc2021.Helper;

public class Files
{
    public static async Task<string> ReadAsync(string path)
    {
        var bytes = await File.ReadAllBytesAsync(path);
        return Encoding.UTF8.GetString(bytes);
    }
}
