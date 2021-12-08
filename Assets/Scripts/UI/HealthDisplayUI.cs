using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayUI : MonoBehaviour
{
    public Text HealthPointsText;
    public Image RadialHealthBar;

    public void UpdateHealth(float newHealth, float maxHealth)
    {
        HealthPointsText.text = Mathf.RoundToInt(newHealth).ToString();
        RadialHealthBar.fillAmount = (float) newHealth / (float) maxHealth;
    }
}