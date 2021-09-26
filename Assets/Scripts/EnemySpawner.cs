using System.Collections.Generic;
using Madasski.Core;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerCharacter Player;
    public List<EnemyCharacter> EnemiesToSpawn;
    public float DelayBetweenSpawns;
    public Collider LevelBoundsCollider;

    private float _timeSinceLastSpawn = 0f;
    private Bounds _levelBounds;

    private void Awake()
    {
        _levelBounds = LevelBoundsCollider.bounds;
        foreach (var enemyCharacter in EnemiesToSpawn)
        {
            ObjectPool.AddObjectToPool(enemyCharacter);
        }
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= DelayBetweenSpawns)
        {
            var randomPosition = GenerateRandomPositionInsideLevelBounds();
            var randomEnemy = EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Count)];
            Spawn(randomEnemy, randomPosition);
            _timeSinceLastSpawn = 0f;
        }
    }

    private Vector3 GenerateRandomPositionInsideLevelBounds()
    {
        var randomX = Random.Range(-_levelBounds.extents.x, _levelBounds.extents.x);
        var randomZ = Random.Range(-_levelBounds.extents.z, _levelBounds.extents.z);

        var randomPosition = new Vector3(randomX, 0f, randomZ);

        return randomPosition;
    }

    private void Spawn(EnemyCharacter gameObjectToSpawn, Vector3 spawnPosition)
    {
        var spawnedObject = ObjectPool.GetObject(gameObjectToSpawn);
        spawnedObject.gameObject.SetActive(true);
        spawnedObject.transform.position = spawnPosition;
        if (Player)
            spawnedObject.Player = Player;
    }
}