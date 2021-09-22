using UnityEngine;

namespace Game.Weapons
{
    public class Projectile: MonoBehaviour
    {
        public float Speed;
        
        private void Update()
        {
            transform.position += transform.forward*Time.deltaTime*Speed;
        }
    }
}

