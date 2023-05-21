namespace RecipePlanner.Shared;

public class UserDto
{
    public Guid Id { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<UserRecipeDto> SavedRecipes { get; set; } = new();
    // public List<Recipe> UploadedRecipes { get; set; } = new();
}