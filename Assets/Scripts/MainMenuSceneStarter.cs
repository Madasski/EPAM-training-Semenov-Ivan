using Composition;
using Core.Sound;
using UnityEngine;

public class MainMenuSceneStarter : MonoBehaviour
{
    [SerializeField] private AudioClip _menuMusic;
    
    private IMainMenu _mainMenu;
    private AudioManager _audioManager;

    private void Awake()
    {
        _mainMenu = CompositionRoot.GetMainMenu();
        _audioManager = CompositionRoot.GetAudioManager();
    }

    private void Start()
    {
        _mainMenu.Show();
        _audioManager.PlayMusic(_menuMusic);
    }
}