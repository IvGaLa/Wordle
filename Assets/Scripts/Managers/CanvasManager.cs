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

    public void LoadMain(bool main) // If main is true "Load main canvas", if false "Load game canvas"
    {
        mainCanvas.gameObject.SetActive(main);
        gameCanvas.gameObject.SetActive(!main);
    }

}