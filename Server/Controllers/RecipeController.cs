using Microsoft.AspNetCore.Mvc;

namespace RecipePlanner.Server.Controllers.RecipeController;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Recipe>>>> GetRecipes()
    {
        var result = await _recipeService.GetRecipes();
        return Ok(result);
    }
}