using Microsoft.Win32;
using System.Reflection;
using System.Text.Json;

namespace ScReader
{
    internal class Settings
    {
        private RegistryKey _write;

        public int Top { get; set; } = 50;
        public int Left { get; set; } = 50;
        public string SavePath { get; set; } = $@"{Application.StartupPath}ScReaderImages";
        public bool AutoStart { get; set; }
        public bool SaveImage { get; set; } = true;

        private string _settingsPath = $@"{Application.StartupPath}settings.json";

        public Settings ReadConfig(Settings settings)
        {
            if (File.Exists(_settingsPath))
            {
                using (Stream file = new FileStream(_settingsPath, FileMode.OpenOrCreate))
                {
                    using (StreamReader reader = new(file))
                    {
                        return JsonSerializer.Deserialize<Settings>(reader.ReadToEnd());
                    }
                }
            }
            else
            {
                WriteConfig(settings);
                return this;
            }
        }
        public void WriteConfig(Settings settings)
        {
            if (AutoStart)
            {
                using (_write = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (_write.GetValue("ScReader") == null)
                    {
                        string appPath = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
                        _write.SetValue("ScReader", appPath);
                    }
                }
            }
            else
            {
                using (_write = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (_write.GetValue("ScReader") != null)
                        _write.DeleteValue("ScReader");
                }
            }

            if (File.Exists(_settingsPath))
            {
                File.Delete(_settingsPath);
                using (Stream file = new FileStream(_settingsPath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new(file))
                    {
                        string temp = JsonSerializer.Serialize(settings);
                        writer.WriteLine(temp);
                    }
                }
            }
            else
            {
                using (Stream file = new FileStream(_settingsPath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new(file))
                    {
                        string temp = JsonSerializer.Serialize(settings);
                        writer.WriteLine(temp);
                    }
                }
            }
        }
    }
}
