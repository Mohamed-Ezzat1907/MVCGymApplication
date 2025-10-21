using Route.GYM.DAL.Models.Category;
using Route.GYM.DAL.Models.Plan;
using Route.GYM.DAL.Persistence.Data.Contexts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Route.GYM.DAL.Persistence.Data.DataSeeds
{
    public static class GymDataSeeding
    {
        public static bool SeedData(GymDbContext context)
        {
            try
            {
                if(!context.Categories.Any())
                {
                    var categories = LoadDataFromJsonFile<Category>("categories.json");

                    context.Categories.AddRange(categories);
                }

                if(!context.plans.Any())
                {
                    var plans = LoadDataFromJsonFile<plan>("plans.json");

                    context.plans.AddRange(plans);
                }

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
               return false;    
            }

        }


        private static List<T> LoadDataFromJsonFile<T>(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot\\Files" , fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file {fileName} was not found at path {filePath}.");

            var jsonData = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
              PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter()); 

            return JsonSerializer.Deserialize<List<T>>(jsonData, options) ?? new List<T>();

        }
    }
}
