using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Tile : MonoBehaviour
{
    public TileState state { get; private set; }
    public char letter { get; private set; }

    [SerializeField] TMP_Text text;
    [SerializeField] Image fill;
    [SerializeField] Outline outline;

    public void SetLetter(char letter)
    {
        this.letter = letter;
        text.text = letter.ToString();
    }

    public void SetState(TileState state)
    {
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;
    }
}
