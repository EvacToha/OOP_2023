namespace OOP.Domain.DataBaseSettings;

public class TextDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TextCollectionName { get; set; } = null!;
}