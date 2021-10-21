using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text PowerText;
    public Text SpeedText;
    public Text LevelText;

    //todo: display should not be responsible for tracking level
    private int _currentLevel = 1;

    private void Awake()
    {
        PowerText.text = "POWER:0";
        LevelText.text = "LEVEL:1";
        SpeedText.text = "SPEED:";
    }

    public void UpdatePower(int newPower)
    {
        PowerText.text = "POWER:" + newPower;
    }

    public void UpdateSpeed(int newSpeed)
    {
        SpeedText.text = "SPEED:" + newSpeed;
    }

    public void IncreaseLevel()
    {
        _currentLevel++;
        LevelText.text = "LEVEL:" + _currentLevel;
    }
}