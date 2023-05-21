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

    [HttpGet("{recipeId}")]
    public async Task<ActionResult<ServiceResponse<Recipe>>> GetRecipe(Guid recipeId)
    {
        var result = await _recipeService.GetRecipe(recipeId);
        return Ok(result);
    }

    [HttpDelete("{recipeId}")]
    public async Task<ActionResult<ServiceResponse<Recipe>>> DeleteRecipe(Guid recipeId)
    {
        var result = await _recipeService.DeleteRecipe(recipeId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Recipe>>> CreateRecipe(Recipe recipe)
    {
        var result = await _recipeService.CreateRecipe(recipe);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<Recipe>>> UpdateRecipe(Recipe recipe)
    {
        var result = await _recipeService.UpdateRecipe(recipe);
        return Ok(result);
    }

    [HttpPost("save")]
    public async Task<ActionResult<ServiceResponse<bool>>> SaveRecipe(UserRecipeDto userRecipe)
    {
        var result = await _recipeService.SaveRecipe(userRecipe);
        return Ok(result);
    }
}