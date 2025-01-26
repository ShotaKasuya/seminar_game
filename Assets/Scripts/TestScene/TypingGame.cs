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
