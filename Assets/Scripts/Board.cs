using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random; // To avoid ambiguity with System.Random

public class Board : MonoBehaviour
{
    readonly char charA = 'A', charZ = 'Z', charÑ = 'Ñ';
    int rowIndex, columnIndex, rowsLength, tilesLength;
    [SerializeField] Row[] rows;
    Row currentRow;
    string[] solutions, validWords;
    string word;

    // This is for debugging only
    [SerializeField] TMP_Text wordToDelete;

    public TileState emptyState, occupiedState, correctState, wrongState, incorrectState;

    void Start()
    {
        rowsLength = rows.Length;
        tilesLength = rows[0].tiles.Length;
        LoadWordleList();
        SetRandomWord();
        SetTileSets();
    }

    void SetTileSets()
    {
        // #RRGGBBAA => AA Alpha chanel, FF = 100%
        ColorUtility.TryParseHtmlString("#121213FF", out emptyState.fillColor);
        ColorUtility.TryParseHtmlString("#3A3A3CFF", out emptyState.outlineColor);

        ColorUtility.TryParseHtmlString("#121213FF", out occupiedState.fillColor);
        ColorUtility.TryParseHtmlString("#565758FF", out occupiedState.outlineColor);

        ColorUtility.TryParseHtmlString("#538D4EFF", out correctState.fillColor);
        ColorUtility.TryParseHtmlString("#538D4EFF", out correctState.outlineColor);

        ColorUtility.TryParseHtmlString("#B59F3BFF", out wrongState.fillColor);
        ColorUtility.TryParseHtmlString("#B59F3BFF", out wrongState.outlineColor);

        ColorUtility.TryParseHtmlString("#121213FF", out incorrectState.fillColor);
        ColorUtility.TryParseHtmlString("#121213FF", out incorrectState.outlineColor);
    }

    void Update()
    {
        currentRow = rows[rowIndex];

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DeleteChar();
        }
        else if (columnIndex >= tilesLength)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SubmitRow();
            }
        }
        else
        {
            WriteChar();
        }
    }

    void DeleteChar()
    {
        columnIndex = Math.Max(columnIndex - 1, 0);
        currentRow.tiles[columnIndex].SetLetter('\0'); // Assign null character
        currentRow.tiles[columnIndex].SetState(emptyState);
    }


    void SubmitRow()
    {

        // Check if complete word is correct
        if (IsCorrect())
            WinGame();

        string remaining = word;
        Tile tile;

        for (int i = 0; i < tilesLength; i++)
        {
            tile = currentRow.tiles[i];
            if (tile.letter == word[i])
            {
                tile.SetState(correctState);
                remaining = ReplaceChar(i, remaining);
            }
            else if (!word.Contains(tile.letter))
            {
                tile.SetState(incorrectState);
            }
        }

        for (int i = 0; i < tilesLength; i++)
        {
            tile = currentRow.tiles[i];
            if (tile.state != correctState && tile.state != incorrectState)
            {
                if (remaining.Contains(tile.letter))
                {
                    tile.SetState(wrongState);
                    remaining = ReplaceChar(remaining.IndexOf(tile.letter), remaining);
                }
                else
                {
                    tile.SetState(incorrectState);
                }
            }
        }

        columnIndex = 0;
        rowIndex++;

        if (rowIndex >= rowsLength) // Last row
            GameOver();
    }

    string ReplaceChar(int i, string rem) => rem.Remove(i, 1).Insert(i, " ");

    bool IsCorrect() => word == currentRow.word;

    void WinGame()
    {
        // Win Game
        enabled = false;
    }

    void GameOver()
    {
        // Game over
        enabled = false;
    }

    void WriteChar()
    {
        foreach (char c in Input.inputString)
        {
            char upperChar = char.ToUpper(c);
            if ((upperChar >= charA && upperChar <= charZ) || upperChar == charÑ)
            {
                currentRow.tiles[columnIndex].SetLetter(c);
                currentRow.tiles[columnIndex].SetState(occupiedState);
                columnIndex++;
                break;
            }
        }
    }

    void LoadWordleList()
    {
        string confPath = ConfigValues.GetConfigValue<string>(ConfigTypes.PATH_LANG);
        string language = ConfigValues.GetConfigValue<string>(ConfigTypes.LANGUAGE);
        string wordleFilename = ConfigValues.GetConfigValue<string>(ConfigTypes.WORDLE_FILENAME);
        string filename = $"{confPath}{language}{wordleFilename}";

        TextAsset textFile = Resources.Load(filename) as TextAsset;
        validWords = textFile.text.Split('\n');
    }

    void SetRandomWord()
    {
        word = validWords[Random.Range(0, validWords.Length)].ToLower().Trim();
        word = "hello";
        wordToDelete.text = word;
    }

    void SetLanguage()
    {
        // To-Do
    }
}
