using System.Text.Json.Serialization;

namespace RecipePlanner.Shared;

public class RecipeStep
{
    [JsonIgnore]
    public Recipe? Recipe { get; set; } = null!;
    public Guid RecipeId { get; set; }
    public Guid Id { get; set; }
    public int Index { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool Optional { get; set; }
}