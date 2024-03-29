using System.Text.Json.Serialization;

namespace RecipePlanner.Shared;

public class UserRecipe
{
    public Guid UserId { get; set; }
    public User User { get; set; } = new();
    public Guid RecipeId { get; set; }
    public Recipe Recipe { get; set; } = new();
}