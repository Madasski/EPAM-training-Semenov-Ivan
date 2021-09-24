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
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Use()
        {
            if (_ammoLeft <= 0) return;
            var projectile = Instantiate(ProjectilePrefab, ShootingPoint.position, transform.rotation);
            _ammoLeft--;
        }

        public void Reload()
        {
            _ammoLeft = MagazineSize;
        }
    }
}