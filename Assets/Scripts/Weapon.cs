using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MagazineSize;
    private int ammoLeft;

    private void Awake()
    {
        ammoLeft = MagazineSize;
    }

    public void Shoot()
    {
        if (ammoLeft <= 0) return;
        ammoLeft--;
        Debug.Log("shooting... ammo left: " + ammoLeft);
    }

    public void Reload()
    {
        if (ammoLeft == MagazineSize) return;
        Debug.Log("reload");
        ammoLeft = MagazineSize;
    }
}