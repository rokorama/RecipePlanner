namespace RecipePlanner.Client.Services.RecipeService;

public class RecipeService : IRecipeService
{
    private readonly HttpClient _http;
    public string Message { get; set; } = "Loading...";
    public event Action? RecipesChanged;
    public List<Recipe> Recipes { get; set; } = new();

    public RecipeService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetRecipes()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Recipe>>>("api/recipe");
        if (result is not null && result.Data is not null)
        {
            Recipes = result.Data;
        }

        if (Recipes.Count is 0)
        {
            Message = "No recipes found.";
        }

        RecipesChanged!.Invoke();
    }

    public async Task<ServiceResponse<Recipe>> GetRecipe(Guid recipeId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Recipe>>($"api/recipe/{recipeId}");
        return result!;
    }

    public async Task DeleteRecipe(Recipe recipe)
    {
        await _http.DeleteAsync($"api/recipe/{recipe.Id}");
    }

    public async Task<Recipe> CreateRecipe(Recipe recipe)
    {
        var result = await _http.PostAsJsonAsync("api/recipe", recipe);
        var newRecipe = (await result.Content.ReadFromJsonAsync<ServiceResponse<Recipe>>())!.Data;
        return newRecipe!;
    }

    public async Task<Recipe> UpdateRecipe(Recipe recipe)
    {
        var result = await _http.PutAsJsonAsync($"api/recipe", recipe);
        return (await result.Content.ReadFromJsonAsync<ServiceResponse<Recipe>>())!.Data!;
    }

    public async Task<bool> SaveRecipe(UserRecipe userRecipe)
    {
        var result = await _http.PostAsJsonAsync($"api/recipe/save", userRecipe);
        return (await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>())!.Data!;
    }
}