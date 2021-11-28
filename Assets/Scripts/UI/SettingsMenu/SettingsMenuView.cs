using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsMenuView : SimpleView, ISettingsMenuView
    {
        public event Action BackClicked = () => { };

        // public Toggle BloodToggle;

        [SerializeField] private Button _backButton;
        [SerializeField] private Button _applyButton;

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackClicked);
            _applyButton.onClick.AddListener(OnApplyClicked);
        }


        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackClicked);
            _applyButton.onClick.RemoveListener(OnApplyClicked);
        }

        private void OnBackClicked()
        {
            BackClicked.Invoke();
        }

        private void OnApplyClicked()
        {
            //     Settings.ShowBlood = BloodToggle.isOn;
        }
    }
}