namespace RecipePlanner.Server.Services.RecipeService;

public interface IRecipeService
{
    Task<ServiceResponse<List<Recipe>>> GetRecipes();
    Task<ServiceResponse<Recipe>> GetRecipe(Guid id);
    Task<ServiceResponse<bool>> DeleteRecipe(Guid id);
    Task<ServiceResponse<Recipe>> CreateRecipe(Recipe recipe);
}