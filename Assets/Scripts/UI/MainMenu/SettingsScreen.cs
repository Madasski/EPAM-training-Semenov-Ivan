using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    public Toggle BloodToggle;

    public void Apply()
    {
        Settings.ShowBlood = BloodToggle.isOn;
    }
}