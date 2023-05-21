namespace RecipePlanner.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // var seedUser = new User
        // {
        //     Id = Guid.Parse("9841DBCF-02A4-4BE6-9545-35AFF7DB9C7B"),
        //     Name = "User",
        //     Email = "asd@asd.asd",
        // };

        // modelBuilder.Entity<User>(
        //     u => {
        //         u.HasData(new User
        // {
        //     Id = Guid.Parse("9841DBCF-02A4-4BE6-9545-35AFF7DB9C7B"),
        //     Name = "User",
        //     Email = "asd@asd.asd",
        // });


        // modelBuilder.Entity<Recipe>(
        //     mb => {
        //         mb.HasData( new Recipe
        //         {
        //             Id = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //             Name = "Egg fried rice",
        //             Description = "A simple dish made only with leftover rice and an egg. Feel free to add any other ingredients like vegetables or meat.",
        //             Vegetarian = true,
        //             Vegan = false,
        //             DateCreated = DateTime.Today
        //         });
        //     });


        // modelBuilder.Entity<UserRecipe>().HasData(
        //     new UserRecipe
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         UserId = Guid.Parse("9841DBCF-02A4-4BE6-9545-35AFF7DB9C7B")
        //     });

        // modelBuilder.Entity<RecipeIngredient>().HasData(
        //     new RecipeIngredient
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("68698FB1-DA0E-4058-9295-4B3D949E55E9"),
        //         Name = "Rice",
        //         Quantity = 1,
        //         Measurement = "cup",
        //         Preparation = "cooked"
        //     },
        //     new RecipeIngredient
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("97065633-14B7-457F-8F2E-EA31D2F78D8D"),
        //         Name = "Egg",
        //         Quantity = 1,
        //         Measurement = "cup"
        //     },
        //     new RecipeIngredient
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("D365C0BE-30CA-4A23-B876-B9E51DA0B29E"),
        //         Name = "Soy sauce",
        //         Quantity = 1,
        //         Measurement = "tbsp"
        //     },
        //     new RecipeIngredient
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("4516D7ED-0926-418F-9DF7-A1A2F1855999"),
        //         Name = "Garlic",
        //         Quantity = 1,
        //         Measurement = "clove",
        //         Preparation = "minced"
        //     },
        //     new RecipeIngredient
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("1094E6B3-0EAD-4783-A647-EA85A1CE7CEB"),
        //         Name = "Frozen green peas",
        //         Quantity = 2,
        //         Measurement = "handful",
        //         Optional = true
        //     });

        // modelBuilder.Entity<RecipeStep>().HasData(
        //     new RecipeStep
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("75325287-47B8-42D1-AD74-11F0B614522C"),
        //         Index = 0,
        //         Content = "Heat a pan with some oil on medium-high heat"
        //     },
        //     new RecipeStep
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("637BF9FC-3B13-4BAF-B5D7-5BA8F9943C30"),
        //         Index = 1,
        //         Content = "Crack in the egg and scramble vigorously to break it up into small chunks"
        //     },
        //     new RecipeStep
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("DE2B4F9B-681D-40C5-8D31-951E527C5FDF"),
        //         Index = 2,
        //         Content = "Add the garlic and cook until fragrant"
        //     },
        //     new RecipeStep
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("43E87089-2BE8-48C2-BB63-48512A778B77"),
        //         Index = 3,
        //         Content = "Dump in the rice and start breaking the clumps into individual grains"
        //     },
        //     new RecipeStep
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("BEEF6720-D0C3-4BC0-9AB5-626BED117797"),
        //         Index = 4,
        //         Content = "Once the rice is heated through and slightly toasty, add the soy sauce and mix throughout"
        //     },
        //     new RecipeStep
        //     {
        //         RecipeId = Guid.Parse("2A3D6C16-98F9-47BF-AD3A-5ED26EC20651"),
        //         Id = Guid.Parse("FA1C36E4-D7C7-43AA-AF82-2E5584662F5F"),
        //         Index = 5,
        //         Content = "Add in any additional ingredients such as frozen peas and let them heat through",
        //         Optional = true
        //     });


            modelBuilder.Entity<UserRecipe>(
                mb => {
                    mb.HasOne(ur => ur.User)
                      .WithMany(u => u.SavedRecipes)
                      .HasForeignKey(ur => ur.UserId)
                      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRecipe>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.SavedRecipes)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<UserRecipe>()
                .HasOne(ur => ur.Recipe)
                .WithMany(r => r.SavedBy)
                .HasForeignKey(ur => ur.RecipeId);
        });
    }

    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    public DbSet<RecipeStep> RecipeSteps { get; set; } = null!;
    public DbSet<RecipeTag> RecipeTags { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    // public DbSet<UploadedRecipe> UploadedRecipes { get; set; } = null!;
    // public DbSet<SavedRecipe> SavedRecipes { get; set; } = null!;
    public DbSet<UserRecipe> UserRecipes { get; set; } = null!;
}