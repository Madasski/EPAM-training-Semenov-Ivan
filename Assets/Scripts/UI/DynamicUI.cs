using UnityEngine;

namespace UI
{
    public class DynamicUI : MonoBehaviour
    {
        [SerializeField] private EnemyHealthBarManager enemyHealthBarManager;

        public EnemyHealthBarManager EnemyHealthBarManager => enemyHealthBarManager;
    }
}