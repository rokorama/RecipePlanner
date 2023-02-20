using System.Text.Json.Serialization;

namespace RecipePlanner.Shared;

public class Image
{
    public Guid Id { get; set; }
    public string Data { get; set; } = string.Empty;
}