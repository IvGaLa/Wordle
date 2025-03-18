using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] Canvas mainCanvas, gameCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMain()
    {
        mainCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        mainCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
    }

}