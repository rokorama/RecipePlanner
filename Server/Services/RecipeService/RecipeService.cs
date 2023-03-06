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
                                         .Include(r => r.Tags)
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

    public async Task<ServiceResponse<Recipe>> UpdateRecipe(Recipe recipe)
    {
        var dbRecipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipe.Id);
        if (dbRecipe is null)
        {
            return new ServiceResponse<Recipe>
            {
                Success = false,
                Message = "Recipe with given id not found"
            };
        }

        dbRecipe.Name = recipe.Name;
        dbRecipe.Description = recipe.Description;
        dbRecipe.Vegetarian = recipe.Vegetarian;
        dbRecipe.Vegan = recipe.Vegan;
        dbRecipe.Image = recipe.Image;
        dbRecipe.Source = recipe.Source;

        foreach (var tag in recipe.Tags)
        {
            var dbTag = await _context.RecipeTags.SingleOrDefaultAsync(t => t.Id == tag.Id);
            if (dbTag is null)
            {
                _context.RecipeTags.Add(tag);
            }
            else
            {
                dbTag.Content = tag.Content; 
            }
        }

        foreach (var ingredient in recipe.Ingredients)
        {
            var dbIngredient = await _context.RecipeIngredients.SingleOrDefaultAsync(i => i.Id == ingredient.Id);
            if (dbIngredient is null)
            {
                _context.RecipeIngredients.Add(ingredient);
            }
            else
            {
                dbIngredient.Name = ingredient.Name;
                dbIngredient.Quantity = ingredient.Quantity;
                dbIngredient.Measurement = ingredient.Measurement;
                dbIngredient.Preparation = ingredient.Preparation;
                dbIngredient.Optional = ingredient.Optional;
            }
        }
        foreach (var step in recipe.Steps)
        {
            var dbStep = await _context.RecipeSteps.SingleOrDefaultAsync(s => s.Id == step.Id);
            if (dbStep is null)
            {
                _context.RecipeSteps.Add(step);
            }
            else
            {
                dbStep.Index = step.Index;
                dbStep.Content = step.Content;
                dbStep.Optional = step.Optional; 
            }
        }

        await _context.SaveChangesAsync();
        return new ServiceResponse<Recipe> { Data = recipe };
    }
}