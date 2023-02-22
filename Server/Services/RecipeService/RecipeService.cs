namespace RecipePlanner.Server.Services.RecipeService;

public class RecipeService : IRecipeService
{
    private readonly DataContext _context;

    public RecipeService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Recipe>>> GetRecipes()
    {
        var response = new ServiceResponse<List<Recipe>>()
        {
            Data = await _context.Recipes.Include(r => r.Ingredients)
                                         .Include(r => r.Steps)
                                         .ToListAsync()
        };
        return response;
    }

    public async Task<ServiceResponse<Recipe>> GetRecipe(Guid id)
    {
        var response = new ServiceResponse<Recipe>()
        {
            Data = await _context.Recipes.Include(r => r.Ingredients)
                                         .Include(r => r.Steps)
                                         .FirstOrDefaultAsync(r => r.Id == id)
        };
        return response;
    }

    public async Task<ServiceResponse<bool>> DeleteRecipe(Guid recipeId)
    {
        var recipeToDelete = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
        if (recipeToDelete is not null)
            _context.Recipes.Remove(recipeToDelete!);
        var success = await _context.SaveChangesAsync();
        return new ServiceResponse<bool>()
        {
            Data = success > 0
        };
    }

    public async Task<ServiceResponse<Recipe>> CreateRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
        return new ServiceResponse<Recipe> { Data = recipe };
    }
}