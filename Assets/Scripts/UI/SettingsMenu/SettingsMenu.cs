using System;
using Composition;
using UnityEngine;

namespace UI
{
    public class SettingsMenu : MonoBehaviour, ISettingsMenu
    {
        public event Action BackClicked = () => { };

        private ISettingsMenuView _view;

        private void Awake()
        {
            var viewFactory = CompositionRoot.GetViewFactory();

            _view = viewFactory.CreateSettingsMenu();
        }

        private void OnEnable()
        {
            _view.BackClicked += OnBackClicked;
        }

        private void OnDisable()
        {
            _view.BackClicked -= OnBackClicked;
        }

        public void Show()
        {
            _view.Show();
        }

        public void Hide()
        {
            _view.Hide();
        }


        private void OnBackClicked()
        {
            Hide();
            BackClicked.Invoke();
        }
    }
}