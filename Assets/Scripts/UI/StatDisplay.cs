using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text PowerText;
    public Text SpeedText;
    public Text LevelText;

    //TODO: display should not be responsible for tracking level
    // private int _currentLevel = 1;

    public void SetPower(int newPower)
    {
        PowerText.text = "POWER:" + newPower;
    }

    public void SetSpeed(int newSpeed)
    {
        SpeedText.text = "SPEED:" + newSpeed;
    }

    public void SetLevel(int level)
    {
        LevelText.text = "LEVEL:" + level;
    }
}