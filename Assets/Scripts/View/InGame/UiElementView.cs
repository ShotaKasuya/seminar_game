using System;
using Domain.IView.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace View.InGame
{
    public class UiElementView : MonoBehaviour, ITimerView, IInputView, IWordView, IScoreView
    {
        [SerializeField] private Text wordDisplayText;
        [SerializeField] private InputField inputField;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timerText;

        private void Awake()
        {
            inputField.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(string str)
        {
            ValueChangedEvent?.Invoke(str);
        }
        
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
           scoreText.text = score.ToString(); 
        }
    }
}