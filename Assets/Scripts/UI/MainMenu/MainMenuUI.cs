using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject SettingsScreen;

    private void Awake()
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        MenuScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }

    public void ShowSettings()
    {
        MenuScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }
}