using System;
using System.Collections.Generic;
using Composition;
using Madasski.Core;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public event Action<EnemyCharacter> EnemySpawned;
    public event Action<EnemyCharacter> EnemyDied;

    public List<EnemyCharacter> EnemiesToSpawn;
    public float DelayBetweenSpawns;

    private IPlayerCharacter _player;
    private float _timeSinceLastSpawn = 0f;

    private void Awake()
    {
        _player = CompositionRoot.GetPlayerCharacter();

        foreach (var enemyCharacter in EnemiesToSpawn)
        {
            ObjectPool.Instance.CreatePool(enemyCharacter);
        }
    }

    private void Start()
    {
        Spawn(EnemiesToSpawn[1], transform.position);
    }

    private void Update()
    {
        if (_player == null) return;
        
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= DelayBetweenSpawns)
        {
            var randomEnemy = EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Count)];
            Spawn(randomEnemy, transform.position);
            _timeSinceLastSpawn = 0f;
        }
    }

    private void Spawn(EnemyCharacter gameObjectToSpawn, Vector3 spawnPosition)
    {
        var spawnedObject = ObjectPool.Instance.Spawn(gameObjectToSpawn);
        spawnedObject.transform.position = spawnPosition;
        if (_player != null)
            spawnedObject.SetPlayer(_player);
        spawnedObject.Died += OnEnemyDied;
        EnemySpawned?.Invoke(spawnedObject);
    }

    private void OnEnemyDied(ICharacter character)
    {
        character.Died -= OnEnemyDied;
        EnemyDied?.Invoke(character as EnemyCharacter);
    }
}