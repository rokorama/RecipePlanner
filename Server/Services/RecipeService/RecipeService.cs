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
        var recipe = await _context.Recipes.Include(r => r.Ingredients)
                                           .Include(r => r.Steps)
                                           .Include(r => r.Tags)
                                           .FirstOrDefaultAsync(r => r.Id == id);
        if (recipe is not null)
            recipe.Steps = recipe.Steps.OrderBy(s => s.Index).ToList();
        var response = new ServiceResponse<Recipe>() { Data = recipe};

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
        var dbRecipe = await _context.Recipes.Include(r => r.Tags)
                                             .Include(r => r.Ingredients)
                                             .Include(r => r.Steps)
                                             .FirstOrDefaultAsync(r => r.Id == recipe.Id);
        if (dbRecipe is null)
        {
            return new ServiceResponse<Recipe>
            {
                Success = false,
                Message = "Recipe with given id not found"
            };
        }

        foreach (var dbTag in recipe.Tags)
        {
            Console.WriteLine($"Sent request with tag {dbTag.Id} attached to recipe {dbTag.RecipeId}");
        }

        dbRecipe.Name = recipe.Name;
        dbRecipe.Description = recipe.Description;
        dbRecipe.Vegetarian = recipe.Vegetarian;
        dbRecipe.Vegan = recipe.Vegan;
        dbRecipe.Image = recipe.Image;
        dbRecipe.Source = recipe.Source;

        var existingTags = _context.RecipeTags.Where(t => t.RecipeId == recipe.Id);
        foreach(var oldTag in existingTags)
        {
            _context.RecipeTags.Remove(oldTag);
        }

        foreach (var tag in recipe.Tags)
        {
            RecipeTag newTag = new()
            {
                Id = tag.Id,
                Content = tag.Content,
                RecipeId = dbRecipe.Id,
                Recipe = dbRecipe
            };
            _context.RecipeTags.Add(newTag);
        }

        var existingIngredients = _context.RecipeIngredients.Where(t => t.RecipeId == recipe.Id);
        foreach(var oldIngredient in existingIngredients)
        {
            _context.RecipeIngredients.Remove(oldIngredient);
        }

        foreach (var ingredient in recipe.Ingredients)
        {
            RecipeIngredient newIngredient = new()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                Measurement = ingredient.Measurement,
                Preparation = ingredient.Preparation,
                Optional = ingredient.Optional,
                RecipeId = dbRecipe.Id,
            };
            _context.RecipeIngredients.Add(newIngredient);
        }

        // foreach (var ingredient in recipe.Ingredients)
        // {
        //     var dbIngredient = await _context.RecipeIngredients.SingleOrDefaultAsync(i => i.Id == ingredient.Id);
        //     if (dbIngredient is null)
        //     {
        //         _context.RecipeIngredients.Add(ingredient);
        //     }
        //     else
        //     {
        //         dbIngredient.Name = ingredient.Name;
        //         dbIngredient.Quantity = ingredient.Quantity;
        //         dbIngredient.Measurement = ingredient.Measurement;
        //         dbIngredient.Preparation = ingredient.Preparation;
        //         dbIngredient.Optional = ingredient.Optional;
        //     }
        // }

        var existingSteps = _context.RecipeSteps.Where(t => t.RecipeId == recipe.Id);
        foreach(var oldStep in existingSteps)
        {
            _context.RecipeSteps.Remove(oldStep);
        }        

        foreach (var step in recipe.Steps)
        {
            RecipeStep newStep = new()
            {
                Id = step.Id,
                Index = step.Index,
                Content = step.Content,
                Optional = step.Optional,
                RecipeId = dbRecipe.Id,
                Recipe = dbRecipe
            };
            _context.RecipeSteps.Add(newStep);
        }

        await _context.SaveChangesAsync();
        return new ServiceResponse<Recipe> { Data = recipe };
    }

    public async Task<ServiceResponse<bool>> SaveRecipe(UserRecipeDto userRecipe)
    {
        var dbUserRecipe = await _context.UserRecipes.FirstOrDefaultAsync(ur => ur.UserId == userRecipe.UserId && ur.RecipeId == userRecipe.RecipeId);
        if (dbUserRecipe is not null)
        {
            _context.UserRecipes.Remove(dbUserRecipe);
        }
        else
        {
            UserRecipe newUserRecipe = new()
            {
                UserId = userRecipe.UserId,
                User = await _context!.Users!.FirstOrDefaultAsync(u => u.Id == userRecipe.UserId),
                RecipeId = userRecipe.RecipeId,
                Recipe = await _context!.Recipes!.FirstOrDefaultAsync(r => r.Id == userRecipe.RecipeId)
            };
            _context.UserRecipes.Add(newUserRecipe);
        }
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true };
    }

    public async Task<ServiceResponse<List<UserRecipeDto>>> GetSavedRecipes(Guid userId)
    {
        var savedRecipes = await _context.UserRecipes.Where(ur => ur.UserId == userId).ToListAsync();
        var savedRecipesDto = new List<UserRecipeDto>();
        foreach (var savedRecipe in savedRecipes)
        {
            savedRecipesDto.Add(new UserRecipeDto
            {
                UserId = savedRecipe.UserId,
                RecipeId = savedRecipe.RecipeId
            });
        }
        return new ServiceResponse<List<UserRecipeDto>> { Data = savedRecipesDto };
    }
}