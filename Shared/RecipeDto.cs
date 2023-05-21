using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecipePlanner.Shared;

public class RecipeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RecipeIngredient> Ingredients { get; set; } = new();
    public List<RecipeStep> Steps { get; set; } = new();
    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }
    public Image? Image { get; set; } = null!;
    public DateTime DateCreated { get; set; } = DateTime.Today;
    public List<RecipeTag> Tags { get; set; } = new();
    public Guid UploadedById { get; set; }
    public List<Guid> SavedBy { get; set; } = new();
    public string? Source { get; set; }
    [NotMapped]
    public bool Editing { get; set; } = false;
    [NotMapped]
    public bool IsNew { get; set; } = false;
}