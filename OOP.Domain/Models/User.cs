namespace OOP.Domain.Models;
public class User : BaseEntity
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public int Texts { get; set; }
    public int Points { get; set; }
    public float Speed { get; set; }
    public List<Result> ResultsLog { get; set; }
}