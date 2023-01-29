namespace RecipePlanner.Shared;

public class RecipeStep
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int Index { get; set; }
}