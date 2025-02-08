using Domain.IView.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace View.InGame
{
    public class UiElementView : MonoBehaviour, ITimerView
    {
        [SerializeField] private Text wordDisplayText;
        [SerializeField] private InputField inputField;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timerText;
        public void SetTime(float time)
        {
        }
    }
}