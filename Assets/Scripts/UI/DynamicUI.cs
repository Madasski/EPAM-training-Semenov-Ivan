using UnityEngine;

namespace UI
{
    public class DynamicUI : MonoBehaviour
    {
        [SerializeField] private EnemyHealthBarManager _enemyHealthBarManager;

        public EnemyHealthBarManager EnemyHealthBarManager => _enemyHealthBarManager;
    }
}