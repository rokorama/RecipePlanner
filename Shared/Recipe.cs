namespace RecipePlanner.Shared;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RecipeIngredient> Ingredients { get; set; } = new();
    public List<RecipeStep> Steps { get; set; } = new();
    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }
    public DateTime DateCreated { get; set; }
    public Guid UploadedBy { get; set; }
    public string? Source { get; set; }
}