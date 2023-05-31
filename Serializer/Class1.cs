using System.Text;
using System.Text.Json;

namespace Serializer;

public static class SerializerJson
{
    public static async Task<string> Serialize<T>(T value)
    {
        using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, value, value?.GetType()!);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
    
    public static async Task SerializeToFile<T>(T value, string filePath)
    {
        await using var filestream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(filestream, value, value?.GetType()!);
        await filestream.DisposeAsync();
    }
    
    public static async Task<T?> Deserialize<T>(string json)
    {
        var buffer = Encoding.Default.GetBytes(json);
        using var stream = new MemoryStream(buffer);
        var value = await JsonSerializer.DeserializeAsync<T>(stream);
        return value;
    }
    
    public static async Task<T?> DeserializeFromFile<T>(string filePath)
    {
        var jsonSting = await File.ReadAllTextAsync(filePath);
        var buffer = Encoding.Default.GetBytes(jsonSting);
        using var stream = new MemoryStream(buffer);
        var value = await JsonSerializer.DeserializeAsync<T>(stream);
        return value;
    }
        
}