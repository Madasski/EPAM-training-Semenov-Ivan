using Madasski.Core;
using UnityEngine;

namespace Game.Weapons
{
    public class FireArm : Weapon
    {
        public Projectile ProjectilePrefab;
        public Transform ShootingPoint;
        public int MagazineSize;

        private int _ammoLeft;

        protected void Awake()
        {
            _ammoLeft = MagazineSize;
            ObjectPool.Instance.AddObjectToPool(ProjectilePrefab);
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Use()
        {
            if (_ammoLeft <= 0) return;
            // var projectile = Instantiate(ProjectilePrefab, ShootingPoint.position, transform.rotation);
            var projectile = ObjectPool.Instance.GetObject(ProjectilePrefab);
            projectile.transform.position = ShootingPoint.position;
            projectile.transform.rotation = transform.rotation;
            _ammoLeft--;
        }

        public void Reload()
        {
            _ammoLeft = MagazineSize;
        }
    }
}