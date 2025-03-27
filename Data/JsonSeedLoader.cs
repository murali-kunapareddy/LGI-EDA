using System.Text.Json;

namespace WISSEN.EDA.Data
{
    public class JsonSeedLoader
    {
        public static List<T> LoadFromJson<T>(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading JSON file: {filePath}", ex);
            }
        }
    }
}
