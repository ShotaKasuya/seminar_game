using System;
using Domain.IView.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace View.InGame
{
    public class UiElementView : MonoBehaviour, ITimerView, IQuestionView, IScoreView
    {
        [SerializeField] private Text wordDisplayText;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timerText;

        public void SetTime(float time)
        {
            timerText.text = time.ToString("F2");
        }

        public Action<string> ValueChangedEvent { get; set; }

        public void ShowText(string text)
        {
            wordDisplayText.text = text;
        }

        public void SetScore(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}