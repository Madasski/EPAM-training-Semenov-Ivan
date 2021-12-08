using Composition;
using Core.Saving;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IMainMenu
{
    private IMainMenuView _view;
    private ISettingsMenu _settingsMenu;
    private ISaveLoadManager _saveLoadManager;

    private void Awake()
    {
        _saveLoadManager = CompositionRoot.GetSaveLoadManager();
        _settingsMenu = CompositionRoot.GetSettingsMenu();
        var viewFactory = CompositionRoot.GetViewFactory();

        _view = viewFactory.CreateMainMenu();
    }

    private void OnEnable()
    {
        _view.SettingsClicked += OnSettingsClicked;
        _view.NewGameClicked += OnNewGameClicked;
        _view.LoadGameClicked += OnLoadGameClicked;
        _settingsMenu.BackClicked += Show;
    }

    private void OnDisable()
    {
        _view.SettingsClicked -= OnSettingsClicked;
        _view.NewGameClicked -= OnNewGameClicked;
        _view.LoadGameClicked -= OnLoadGameClicked;
        _settingsMenu.BackClicked -= Show;
    }

    private void Start()
    {
        _settingsMenu.Hide();
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    private void OnSettingsClicked()
    {
        Hide();
        _settingsMenu.Show();
    }

    private void OnNewGameClicked()
    {
        SceneManager.LoadScene(Scenes.NewGame);
    }

    private void OnLoadGameClicked()
    {
        _saveLoadManager.LoadGameData();
        SceneManager.LoadScene(Scenes.NewGame);
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }
}