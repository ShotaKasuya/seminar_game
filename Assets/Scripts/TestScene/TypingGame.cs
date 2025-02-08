using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Domain.IView.InGame;
using Installer;
using Module.Serial;

public class TypingGame : MonoBehaviour
{
    // private string currentWord;
    // private int score = 0;
    // private float timeRemaining;
    // private bool isGameRunning = false;
    //
    // void Start()
    // {
    //     inputField.onValueChanged.AddListener(OnInputChanged);
    //     StartGame();
    // }
    //
    // void StartGame()
    // {
    //     timeRemaining = gameTime;
    //     score = 0;
    //     isGameRunning = true;
    //     GenerateNewWord();
    //     UpdateUI();
    // }
    //
    // void Update()
    // {
    //     if (isGameRunning)
    //     {
    //         timeRemaining -= Time.deltaTime;
    //         if (timeRemaining <= 0)
    //         {
    //             EndGame();
    //         }
    //         UpdateTimerUI();
    //     }
    // }
    //
    // void GenerateNewWord()
    // {
    //     if (wordList.Count > 0)
    //     {
    //         currentWord = wordList[Random.Range(0, wordList.Count)];
    //         wordDisplayText.text = currentWord;
    //         inputField.text = "";
    //     }
    // }
    //
    // void OnInputChanged(string input)
    // {
    //     if (!isGameRunning) return;
    //
    //     if (input.Length > currentWord.Length)
    //     {
    //         inputField.text = input.Substring(0, currentWord.Length);
    //         return;
    //     }
    //
    //     for (int i = 0; i < input.Length; i++)
    //     {
    //         if (input[i] != currentWord[i])
    //         {
    //             inputField.text = input[..i];
    //             inputField.caretPosition = inputField.text.Length;
    //             return;
    //         }
    //     }
    //
    //     if (input.Equals(currentWord))
    //     {
    //         score++;
    //         GenerateNewWord();
    //         UpdateScoreUI();
    //     }
    // }
    //
    // void UpdateUI()
    // {
    //     UpdateScoreUI();
    //     UpdateTimerUI();
    // }
    //
    // void UpdateScoreUI()
    // {
    //     scoreText.text = "Score: " + score;
    // }
    //
    // void UpdateTimerUI()
    // {
    //     timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    // }
    //
    // void EndGame()
    // {
    //     isGameRunning = false;
    //     wordDisplayText.text = "Game Over!";
    //     inputField.interactable = false;
    // }
}
