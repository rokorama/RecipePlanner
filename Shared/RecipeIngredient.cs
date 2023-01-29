namespace RecipePlanner.Shared;

public class RecipeIngredient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public string Measurement { get; set; } = string.Empty;
}