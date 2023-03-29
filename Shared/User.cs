namespace RecipePlanner.Shared;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Recipe> SavedRecipes { get; set; } = new();
    public List<Recipe> UploadedRecipes { get; set; } = new();
    public DateTime DateCreated { get; set; } = DateTime.Today;
    public string Role { get; set; } = "user";
}