using Madasski.Core;
using UnityEngine;

namespace Game.Weapons
{
    public class Firearm : Weapon
    {
        public Projectile ProjectilePrefab;
        public Transform ShootingPoint;
        public int MagazineSize;

        private int _ammoLeft;

        public int AmmoLeft => _ammoLeft;

        protected void Awake()
        {
            _ammoLeft = MagazineSize;
            ObjectPool.Instance.CreatePool(ProjectilePrefab);
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Use(float additionalDamage = 0)
        {
            if (_ammoLeft <= 0) return;
            var projectile = ObjectPool.Instance.Spawn(ProjectilePrefab, transform.rotation);
            projectile.transform.position = ShootingPoint.position;
            // projectile.transform.rotation = transform.rotation;
            _ammoLeft--;
        }

        public void Reload()
        {
            _ammoLeft = MagazineSize;
        }
    }
}