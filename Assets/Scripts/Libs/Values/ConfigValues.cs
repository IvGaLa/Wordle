using System.Collections.Generic;

public class ConfigValues
{
  static readonly Dictionary<ConfigTypes, object> _config = new()
  {

    { ConfigTypes.AUTHOR, new Config<string>("IvGaLa") },
    { ConfigTypes.TITLE, new Config<string>("Wordle") },
    { ConfigTypes.GITHUB, new Config<string>("https://github.com/IvGaLa/Wordle") },

    { ConfigTypes.PATH_LANG, new Config<string>("Lang/") },
    { ConfigTypes.LANGUAGE, new Config<string>($"{LanguageValues.GetLanguage(LanguageTypes.ENGLISH)}/") }, // Default language
    { ConfigTypes.WORDLE_FILENAME, new Config<string>("wordle") },

    { ConfigTypes.SPRITES_PATH, new Config<string>("Sprites/") },
    { ConfigTypes.FLAG_SPRITES_FILENAME, new Config<string>("Flags") },

    
  

    // { ConfigTypes.MUSIC_PATH, new Config<string>("Audio/Music/") },
    // { ConfigTypes.SFX_PATH, new Config<string>("Audio/SFX/") },
  };

  public static void SetConfigValue<T>(ConfigTypes key, T newValue)
  {
    if (_config.TryGetValue(key, out object value) && value is Config<T> typedValue)
      typedValue.SetValue(newValue);
  }

  public static T GetConfigValue<T>(ConfigTypes key)
  {
    if (_config.TryGetValue(key, out object value) && value is Config<T> typedValue)
      return typedValue.Value;

    throw new KeyNotFoundException($"Key {key} not found or invalid type.");
  }
}