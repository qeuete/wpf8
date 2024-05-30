using System;
using System.IO;
using System.Text.Json;

namespace LibraryJson
{
    public static class Json
    {
        public static void SerializeToFile<T>(T obj, string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Сериализация успешна => {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    T obj = JsonSerializer.Deserialize<T>(jsonString);
                    Console.WriteLine($"Десериализация успешна => {filePath}");
                    return obj;
                }
                else
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return default;
            }
        }
    }
}
