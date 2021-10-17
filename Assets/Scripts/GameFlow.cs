using UnityEngine;

namespace Madasski
{
    public class GameFlow
    {
        private readonly PlayerCharacter _player;
        private readonly EnemySpawner _enemySpawner;

        public GameFlow(PlayerCharacter player, EnemySpawner enemySpawner)
        {
            _player = player;
            _enemySpawner = enemySpawner;

            Init();
        }

        private void Init()
        {
            _enemySpawner.EnemyDied += enemy => GiveExperienceToPlayer(enemy.experienceForKill);
        }

        private void GiveExperienceToPlayer(int amount)
        {
            _player.ExperienceManager.GainExperience(amount);
        }
    }
}