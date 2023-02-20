namespace RecipePlanner.Client.Services.RecipeService;

public interface IRecipeService
{
    List<Recipe> Recipes { get; set; }
    string Message { get; set; }
    event Action? RecipesChanged;
    Task GetRecipes();
    Task<ServiceResponse<Recipe>> GetRecipe(Guid id);
    Task DeleteRecipe(Recipe recipe);
}