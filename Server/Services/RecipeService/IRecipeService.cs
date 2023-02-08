namespace RecipePlanner.Server.Services.RecipeService;

public interface IRecipeService
{
    Task<ServiceResponse<List<Recipe>>> GetRecipes();
    Task<ServiceResponse<Recipe>> GetRecipe(Guid id);
}