using System.Collections.Generic;

public class LanguageValues
{
  static readonly Dictionary<LanguageTypes, string> _languages = new()
  {
    {LanguageTypes.ENGLISH,"EN"},
    {LanguageTypes.SPANISH,"ES"},
    {LanguageTypes.GREEK,"EL"},
    {LanguageTypes.ROMANIAN,"RO"},
    {LanguageTypes.ITALIAN,"IT"},
    {LanguageTypes.FRENCH,"FR"},
    {LanguageTypes.GERMAN,"DE"},
    {LanguageTypes.RUSSIAN,"RU"},
    {LanguageTypes.BULGARIAN,"BG"},
    {LanguageTypes.HUNGARIAN,"HU"},
    {LanguageTypes.POLISH,"PL"},
    {LanguageTypes.UKRAINIAN,"UK"},
    {LanguageTypes.CZECH,"CS"},
    {LanguageTypes.FINNISH,"FI"},
    {LanguageTypes.SWEDISH,"SV"},
    {LanguageTypes.ICELANDIC,"IS"},
    {LanguageTypes.NORWEGIAN,"NO"},
    {LanguageTypes.DANISH,"DA"},
    {LanguageTypes.UNKNOWN,"XX"},
  };

  public static string GetLanguage(LanguageTypes _lang) => _languages[_lang];

  public static Dictionary<LanguageTypes, string> GetAllLanguages() => _languages;

  public static LanguageTypes GetLanguageType(string langCode)
  {
    foreach (var pair in _languages)
      if (pair.Value == langCode)
        return pair.Key;

    return LanguageTypes.UNKNOWN;
  }

}