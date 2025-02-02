using System;
using System.Collections.Generic;
using Domain.IView.OutGame.SelectSerialPort;
using UnityEngine;
using UnityEngine.UI;

namespace View.OutGame
{
    public class SelectionView : MonoBehaviour, ISelectionView
    {
        [SerializeField] private Dropdown portDropdown;
        [SerializeField] private Text statusText;
        [SerializeField] private Button submitButton;

        public Action DecisionEvent { get; set; }
        public Action<SelectedSerial> SelectEvent { get; set; }
        private void Awake()
        {
            submitButton.onClick.AddListener(OnSubmit);
            portDropdown.onValueChanged.AddListener(InvokeSelectEvent);
        }

        public void UpdateList(List<string> listContents)
        {
            portDropdown.ClearOptions();
            portDropdown.AddOptions(listContents);
            InvokeSelectEvent(0);
        }

        private void OnSubmit()
        {
            DecisionEvent?.Invoke();
        }

        private void InvokeSelectEvent(int index)
        {
            var portName = portDropdown.options[index].text;
            SelectEvent?.Invoke(new SelectedSerial(portName));
        }
    }
}