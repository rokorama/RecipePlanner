using System.Text.Json.Serialization;

namespace RecipePlanner.Shared;

public class RecipeTag
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public Recipe? Recipe { get; set; } = new();
    public Guid RecipeId { get; set; }
    public string Content { get; set; } = string.Empty;

}