using System;
using System.Linq;
using Domain.IView.OutGame.SerialTest;
using Module.Serial;
using UnityEngine;
using UnityEngine.UI;

namespace View.OutGame
{
    public class SerialTestView : MonoBehaviour, ISerialTestView
    {
        [SerializeField] private Dropdown hand;
        [SerializeField] private Dropdown finger;
        [SerializeField] private InputField time;
        [SerializeField] private Button sendButton;

        private void Awake()
        {
            hand.ClearOptions();
            hand.AddOptions(Enum.GetNames(typeof(HandType)).ToList());
            hand.onValueChanged.AddListener(OnHandChange);
            finger.ClearOptions();
            finger.AddOptions(Enum.GetNames(typeof(FingerType)).ToList());
            finger.onValueChanged.AddListener(OnFingerChange);

            time.onEndEdit.AddListener(OnTimeChanged);
            sendButton.onClick.AddListener(InvokeSelectEvent);
        }

        private void InvokeSelectEvent()
        {
            var packet = new Packet(_currentHandType, _currentFingerType, _time);
            OnSend?.Invoke(packet);
        }

        private void OnHandChange(int index)
        {
            var handName = hand.options[index].text;
            var value = Enum.Parse<HandType>(handName);

            _currentHandType = value;
        }

        private void OnFingerChange(int index)
        {
            var fingerName = finger.options[index].text;
            var value = Enum.Parse<FingerType>(fingerName);

            _currentFingerType = value;
        }

        private void OnTimeChanged(string input)
        {
            if (float.TryParse(input, out var result))
            {
                _time = (int)(result * 10);
            }
            else
            {
                Debug.LogWarning("input value is not a number");
            }
        }

        public Action<Packet> OnSend { get; set; }

        private HandType _currentHandType;
        private FingerType _currentFingerType;
        private int _time;
    }
}