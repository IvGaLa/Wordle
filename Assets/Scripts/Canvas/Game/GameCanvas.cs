using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    void OnEnable()
    {
        Board board = FindFirstObjectByType<Board>();
        board.StartGame();
    }
}
