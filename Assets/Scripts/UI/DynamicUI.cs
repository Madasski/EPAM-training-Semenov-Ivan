using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class DynamicUI : MonoBehaviour
    {
        [FormerlySerializedAs("enemyHealthBarManager")] [SerializeField] private HealthBarDrawer healthBarDrawer;

        public HealthBarDrawer HealthBarDrawer => healthBarDrawer;
    }
}