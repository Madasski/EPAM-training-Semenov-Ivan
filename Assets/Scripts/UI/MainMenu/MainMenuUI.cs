using Composition;
using Core;
using UI;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    private MenuScreen _menuScreen;
    private SettingsScreen _settingsScreen;
    private IResourceManager _resourceManager;

    private void Awake()
    {
        _resourceManager = CompositionRoot.GetResourceManager();

        var menuScreenPrefab = _resourceManager.GetPrefab<EScreens, MenuScreen>(EScreens.MainMenuScreen);
        var settingsScreenPrefab = _resourceManager.GetPrefab<EScreens, SettingsScreen>(EScreens.SettingsScreen);

        _menuScreen = Instantiate(menuScreenPrefab, transform);
        _settingsScreen = Instantiate(settingsScreenPrefab, transform);
    }

    private void OnEnable()
    {
        _menuScreen.SettingsButtonClicked += ShowSettings;
        _settingsScreen.BackToMenuButtonPressed += ShowMenu;
    }

    private void OnDisable()
    {
        _menuScreen.SettingsButtonClicked -= ShowSettings;
        _settingsScreen.BackToMenuButtonPressed -= ShowMenu;
    }

    private void Start()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        _menuScreen.Show();
        _settingsScreen.Hide();
    }

    private void ShowSettings()
    {
        _menuScreen.Hide();
        _settingsScreen.Show();
    }
}