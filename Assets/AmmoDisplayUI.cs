using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplayUI : MonoBehaviour
{
    public Image WeaponIcon;
    public Text AmmoText;

    private string _magazineSizeText;

    public void UpdateAmmoCounter(int ammoLeft, int magazineSize)
    {
        _magazineSizeText = magazineSize > 0 ? magazineSize.ToString() : "-";
        string ammoLeftText = ammoLeft >= 0 ? ammoLeft.ToString() : "-";
        AmmoText.text = ammoLeftText + "/" + _magazineSizeText;
    }

    public void UpdateAmmoCounter(int ammoLeft)
    {
        string ammoLeftText = ammoLeft >= 0 ? ammoLeft.ToString() : "-";
        AmmoText.text = ammoLeftText + "/" + _magazineSizeText;
    }
}