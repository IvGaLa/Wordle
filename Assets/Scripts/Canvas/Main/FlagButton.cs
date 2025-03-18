using UnityEngine;
using UnityEngine.UI;

public class FlagButton : MonoBehaviour
{
    LanguageTypes language;
    Button btn;

    void Awake()
    {
        btn = GetComponent<Button>();
        language = LanguageValues.GetLanguageType(name);
    }

    void Start()
    {
        btn.onClick.AddListener(delegate () { MainCanvas.LoadGame(language); });
        btn.image.sprite = SpritesValues.GetSprite(language);
    }
}
