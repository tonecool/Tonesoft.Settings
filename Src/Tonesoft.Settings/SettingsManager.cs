using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Tonesoft.Settings
{
    public class SettingsManager
    {
        private static readonly Dictionary<Type, string> RegisteredTypes = new Dictionary<Type, string>();
        /// <summary>
        /// Registers type as settings file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Relative of apsolute settings file path</param>
        public static void RegisterType<T>(string path = null) where T : new()
        {
            var type = typeof(T);
            if (RegisteredTypes.Keys.Contains(type))
                return;
            RegisteredTypes[type] = CreateSettingsFilePath(type, path);
            LoadSettings(type);
            SaveSettings(type);
        }

        //
        private static void LoadSettings(Type type)
        {
            try
            {
                var file = File.ReadAllText(RegisteredTypes[type]);
                JsonConvert.DeserializeObject(file, type, GetSerializerSettings());
            }
            catch (FileNotFoundException) { }
            catch (DirectoryNotFoundException) { }
        }

        public static void SaveSettings(Type type)
        {
            var json = JsonConvert.SerializeObject(Activator.CreateInstance(type), GetSerializerSettings());
            var filePath = RegisteredTypes[type];
            // ReSharper disable once AssignNullToNotNullAttribute
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, json);
        }

        private static string CreateSettingsFilePath(Type type, string path)
        {
            //default path
            if (path == null)
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, type.Name + ".txt");
            //using provided apsolute path
            if (Path.IsPathRooted(path))
                return path;
            //combine assembly path and relative provided path
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new StaticPropertyContractResolver(),
            };
        }

    }
}
