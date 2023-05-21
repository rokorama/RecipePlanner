namespace RecipePlanner.Server.Services.RecipeService;

public interface IRecipeService
{
    Task<ServiceResponse<List<Recipe>>> GetRecipes();
    Task<ServiceResponse<Recipe>> GetRecipe(Guid id);
    Task<ServiceResponse<bool>> DeleteRecipe(Guid id);
    Task<ServiceResponse<Recipe>> CreateRecipe(Recipe recipe);
    Task<ServiceResponse<Recipe>> UpdateRecipe(Recipe recipe);
    Task<ServiceResponse<bool>> SaveRecipe(UserRecipeDto userRecipe);
    Task<ServiceResponse<List<UserRecipeDto>>> GetSavedRecipes(Guid userId);
}