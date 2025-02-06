using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TypingGame : MonoBehaviour
{
    [Header("UI Elements")]
    public Text wordDisplayText;
    public InputField inputField;
    public Text scoreText;
    public Text timerText;

    [Header("Game Settings")]
    public List<string> wordList;
    public float gameTime = 60f;

    private Dictionary<string, int> fingerPosition = new Dictionary<string, int>()
    {
        { "Q", 1 },
        { "q", 1 },
        { "A", 1 },
        { "a", 1 },
        { "Z", 1 },
        { "z", 1 },
        { "W", 2 },
        { "w", 2 },
        { "S", 2 },
        { "s", 2 },
        { "X", 2 },
        { "x", 2 },
        { "E", 3 },
        { "e", 3 },
        { "D", 3 },
        { "d", 3 },
        { "C", 3 },
        { "c", 3 },
        { "R", 4 },
        { "r", 4 },
        { "F", 4 },
        { "f", 4 },
        { "V", 4 },
        { "v", 4 },
        { "T", 4 },
        { "t", 4 },
        { "G", 4 },
        { "g", 4 },
        { "B", 4 },
        { "b", 4 },
        { "Y", 5 },
        { "y", 5 },
        { "H", 5 },
        { "h", 5 },
        { "N", 5 },
        { "n", 5 },
        { "U", 5 },
        { "u", 5 },
        { "J", 5 },
        { "j", 5 },
        { "M", 5 },
        { "m", 5 },
        { "I", 6 },
        { "i", 6 },
        { "K", 6 },
        { "k", 6 },
        { "O", 7 },
        { "o", 7 },
        { "L", 7 },
        { "l", 7 },
        { "P", 8 },
        { "p", 8 }
    };

    private string currentWord;
    private int score = 0;
    private float timeRemaining;
    private bool isGameRunning = false;

    void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChanged);
        StartGame();
    }

    void StartGame()
    {
        timeRemaining = gameTime;
        score = 0;
        isGameRunning = true;
        GenerateNewWord();
        UpdateUI();
    }

    void Update()
    {
        if (isGameRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                EndGame();
            }
            UpdateTimerUI();
        }
    }

    void GenerateNewWord()
    {
        if (wordList.Count > 0)
        {
            currentWord = wordList[Random.Range(0, wordList.Count)];
            wordDisplayText.text = currentWord;
            inputField.text = "";
        }
    }

    void OnInputChanged(string input)
    {
        if (!isGameRunning) return;

        if (input.Length > currentWord.Length)
        {
            inputField.text = input.Substring(0, currentWord.Length);
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != currentWord[i])
            {
                inputField.text = input.Substring(0, i);
                inputField.caretPosition = inputField.text.Length;
                return;
            }
        }

        if (input.Equals(currentWord))
        {
            score++;
            GenerateNewWord();
            UpdateScoreUI();
        }
    }

    void UpdateUI()
    {
        UpdateScoreUI();
        UpdateTimerUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }

    void EndGame()
    {
        isGameRunning = false;
        wordDisplayText.text = "Game Over!";
        inputField.interactable = false;
    }
}
