using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    Button btn;
    void Awake()
    {
        btn = GetComponent<Button>();
    }

    void Start()
    {
        btn.onClick.AddListener(delegate () { CanvasManager.Instance.LoadMain(true); });
    }
}
