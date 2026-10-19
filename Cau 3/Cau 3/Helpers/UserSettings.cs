using System;
using System.IO;
using System.Text.Json;

namespace Cau_3.Helpers
{
    public class UserSettings
    {
        public string Culture { get; set; } = "vi-VN";

        private static readonly string FolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "QuanLyDaNgoai");

        private static readonly string FilePath = Path.Combine(FolderPath, "usersettings.json");

        public static UserSettings Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
                }
            }
            catch
            {
            }
            return new UserSettings();
        }

        public void Save()
        {
            try
            {
                Directory.CreateDirectory(FolderPath);
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch
            {
            }
        }
    }
}
