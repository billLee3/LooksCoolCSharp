using PowerAppsUIValues.Models;

namespace PowerAppsUIValues
{
    public class DbInitializer
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (context.UISchemas.Any()) return;

            var uiSchemas = new List<UISchema>
            {
                new()
                {
                    Name = "Army Color Scheme Dark",
                    TextColorPrimary = "#000000",
                    TextColorSecondary = "#FFFFFF",
                    TextColorTertiary = "#FFD530",
                    TextColorTertiaryLight = "#FADB61",
                    TextColorTertiaryDark = "#D4AD11",
                    BackgroundColorPrimary = "#FFFFFF",
                    BackgroundColorSecondary = "#6D8196",
                    BackgroundColorTertiary = "#FFD530",
                    BackgroundColorTertiaryLight = "#6D8196",
                    BackgroundColorTertiaryDark = "#D4AD11",
                    PrimaryFontFamily = "Arial",
                    SecondaryFontFamily = "Futura",
                    TertiaryFontFamily = "Roboto",
                }
            };
            context.UISchemas.AddRange(uiSchemas);
            await context.SaveChangesAsync();
        }
    }
}
