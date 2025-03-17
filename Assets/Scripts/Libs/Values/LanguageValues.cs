using System.Collections.Generic;


public class LanguageValues
{
  static readonly Dictionary<LanguageTypes, string> _languages = new()
  {
    {LanguageTypes.ENGLISH, "EN"},
    {LanguageTypes.SPANISH, "ES"},
  };

  public static string GetLanguage(LanguageTypes _lang) => _languages[_lang];
}