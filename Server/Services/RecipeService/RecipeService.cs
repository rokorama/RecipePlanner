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
}