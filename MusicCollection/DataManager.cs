using System.Text.Json;

namespace MusicCollection
{
    public static class DataManager
    {
        public static List<T> LoadData<T>(string fileName)
        {
            if (!File.Exists(fileName)) return new List<T>();

            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void SaveData<T>(List<T> data, string fileName)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}
