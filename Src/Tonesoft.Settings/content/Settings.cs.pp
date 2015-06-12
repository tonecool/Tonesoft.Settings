
namespace $rootnamespace$
{
    class Settings
    {
        public static string StringSetting { get; set; }
        public static int IntSetting { get; set; }

        private static void SetDefaultValues()
        {
            StringSetting = "Test1";
            IntSetting = 5;
        }

        static Settings()
        {
            SetDefaultValues();
            Tonesoft.Settings.SettingsManager.RegisterType<Settings>();
        }
    }
}
