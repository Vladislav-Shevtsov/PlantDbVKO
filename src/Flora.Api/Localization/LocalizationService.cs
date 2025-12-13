using System.Globalization;
using System.Text.Json;

namespace Flora.Api.Localization
{
    public interface ILocalizationService
    {
        string GetTranslation(string key, string? languageCode = null);
    }

    public class LocalizationService : ILocalizationService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations;
        private readonly string _defaultLanguage = "en";

        public LocalizationService()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
            LoadTranslations();
        }

        public string GetTranslation(string key, string? languageCode = null)
        {
            languageCode ??= CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (_translations.TryGetValue(languageCode, out var languageDict))
            {
                if (languageDict.TryGetValue(key, out var translation))
                {
                    return translation;
                }
            }

            // Fallback to default language
            if (_translations.TryGetValue(_defaultLanguage, out var defaultDict))
            {
                if (defaultDict.TryGetValue(key, out var defaultTranslation))
                {
                    return defaultTranslation;
                }
            }

            return key;
        }

        private void LoadTranslations()
        {
            // Load from JSON files in Localization/Resources folder
            var resourcesPath = Path.Combine(AppContext.BaseDirectory, "Localization", "Resources");
            
            if (!Directory.Exists(resourcesPath))
                return;

            foreach (var file in Directory.GetFiles(resourcesPath, "*.json"))
            {
                var languageCode = Path.GetFileNameWithoutExtension(file).Split('.').LastOrDefault() ?? _defaultLanguage;
                try
                {
                    var json = File.ReadAllText(file);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                    if (dict != null)
                    {
                        _translations[languageCode] = dict;
                    }
                }
                catch
                {
                    // Log error, continue
                }
            }
        }
    }
}
