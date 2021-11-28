using Composition;
using UnityEngine;

public class MainMenuSceneStarter : MonoBehaviour
{
    private IMainMenu _mainMenu;

    private void Awake()
    {
        _mainMenu = CompositionRoot.GetMainMenu();
    }

    private void Start()
    {
        _mainMenu.Show();
    }
}