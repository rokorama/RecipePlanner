using System.Text.Json.Serialization;

namespace RecipePlanner.Shared;

public class Image
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public Recipe Recipe { get; set;} = new();
    public Guid RecipeId { get; set; }
    public byte[] Data { get; set; } = new byte[]{};

}