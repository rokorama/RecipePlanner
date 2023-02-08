namespace RecipePlanner.Client.Services.RecipeService;

public interface IRecipeService
{
    List<Recipe> Recipes { get; set; }
    string Message { get; set; }
    event Action? RecipesChanged;
    Task GetRecipes();
}