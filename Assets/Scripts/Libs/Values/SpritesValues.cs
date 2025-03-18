using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SpritesValues
{
  static readonly Dictionary<LanguageTypes, Sprite> spritesDictionary = LoadSprites();

  static Dictionary<LanguageTypes, Sprite> LoadSprites()
  {
    string spritesPath = ConfigValues.GetConfigValue<string>(ConfigTypes.SPRITES_PATH);
    string tilesetName = ConfigValues.GetConfigValue<string>(ConfigTypes.FLAG_SPRITES_FILENAME);
    Sprite[] sprites = Resources.LoadAll<Sprite>(spritesPath + tilesetName);
    Dictionary<LanguageTypes, string> spritesNames = LanguageValues.GetAllLanguages();

    return spritesNames
        .Where(kv => sprites.Any(sprite => sprite.name == kv.Value))
        .ToDictionary(kv => kv.Key, kv => sprites.First(sprite => sprite.name == kv.Value));
  }

  public static Sprite GetSprite(LanguageTypes spriteType) => spritesDictionary[spriteType];
}