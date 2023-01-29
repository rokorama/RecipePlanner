namespace RecipePlanner.Shared;

public class RecipePlanner
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<RecipeIngredient> Ingredients { get; set; } = new();
    public List<RecipeStep> Steps { get; set; } = new();
    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }
    public DateTime DateCreated { get; set; }
    public User UploadedBy { get; set; } = null!;
    public string? Source { get; set; }
}