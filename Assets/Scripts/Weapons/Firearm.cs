using Core.Services;
using Madasski.Core;
using UnityEngine;

namespace Game.Weapons
{
    public class Firearm : Weapon
    {
        [SerializeField] private AudioClip _shootSound;

        public Projectile ProjectilePrefab;
        public Transform ShootingPoint;
        public int MagazineSize;

        [SerializeField] private GameObject _shotEffectPrefab;
        private int _ammoLeft;
        private AudioManager _audioManager;

        public int AmmoLeft => _ammoLeft;

        protected void Awake()
        {
            _ammoLeft = MagazineSize;
            ObjectPool.Instance.CreatePool(ProjectilePrefab);
            _audioManager = ServiceLocator.Instance.Get<AudioManager>();
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
            Instantiate(_shotEffectPrefab, ShootingPoint.position, transform.rotation);
            _audioManager.PlaySound(_shootSound);
            _ammoLeft--;
        }

        public void Reload()
        {
            _ammoLeft = MagazineSize;
        }
    }
}