using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static void LoadGame(LanguageTypes lang)
    {
        Board.SetLanguage(lang);
        CanvasManager.Instance.LoadGame();
    }
}
