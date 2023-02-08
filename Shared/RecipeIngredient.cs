namespace RecipePlanner.Shared;

public class RecipeIngredient
{
    public Guid RecipeId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public string? Measurement { get; set; }
    public string? Preparation { get; set; }
    public bool Optional { get; set; } = false;
}