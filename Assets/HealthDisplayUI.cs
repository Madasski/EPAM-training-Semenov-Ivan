using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayUI : MonoBehaviour
{
    public Text HealthPointsText;
    public Image RadialHealthBar;


    public void UpdateHealth(int newHealth)
    {
        HealthPointsText.text = newHealth.ToString();
        RadialHealthBar.fillAmount = (float) newHealth / 100f;
    }
}