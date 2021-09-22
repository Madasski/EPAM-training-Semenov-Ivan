using UnityEngine;

namespace Game.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public Projectile ProjectilePrefab;
        public Transform ShootingPoint;
        public int MagazineSize;
        public float fireRatePerSecond;

        private int _ammoLeft;
        private float timeSinceLastShot = 999f;

        private void Awake()
        {
            _ammoLeft = MagazineSize;
        }

        private void Update()
        {
            timeSinceLastShot += Time.deltaTime;
        }

        public void Shoot()
        {
            if (timeSinceLastShot <= fireRatePerSecond) return;
            if (_ammoLeft <= 0) return;

            timeSinceLastShot = 0f;

            var projectile = Instantiate(ProjectilePrefab, ShootingPoint.position, transform.rotation);
            _ammoLeft--;
        }

        public void Reload()
        {
            _ammoLeft = MagazineSize;
        }
    }
}