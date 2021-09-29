using System;
using System.Collections.Generic;
using Madasski.Core;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public event Action<EnemyCharacter> OnEnemySpawned;

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
            ObjectPool.Instance.CreatePool(enemyCharacter);
        }
    }

    private void Update()
    {
        if (!Player) return;

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
        var spawnedObject = ObjectPool.Instance.Spawn(gameObjectToSpawn);
        spawnedObject.transform.position = spawnPosition;
        if (Player)
            spawnedObject.Player = Player;
        OnEnemySpawned?.Invoke(spawnedObject);
    }
}