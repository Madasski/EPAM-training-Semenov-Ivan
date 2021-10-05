using System;
using UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelEnd;

    public GameObject UI;
    public GameObject Level;
    public PlayerCharacter Player;
    public EnemySpawner EnemySpawner;
    public CameraFollow Camera;

    private GameProgression _gameProgression;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Instantiate(Level);
        var player = Instantiate(Player);
        var playerCamera = Instantiate(Camera);
        var enemySpawner = Instantiate(EnemySpawner);
        var ui = Instantiate(UI);
        _gameProgression = new GameProgression();

        ui.GetComponentInChildren<HUD>().SetPlayer(player);
        playerCamera.SetTarget(player.transform);

        _gameProgression.SetPlayer(player);

        player.LookTarget = ui.GetComponentInChildren<CrosshairUI>().transform;
        player.OnDie += EndLevel;

        enemySpawner.Player = player;
        enemySpawner.OnEnemySpawned += ui.GetComponentInChildren<EnemyHealthBarManager>().DrawHealthBarForEnemy;
        enemySpawner.OnEnemySpawned += spawnedCharacter => spawnedCharacter.OnDie += deadCharacter => player.GainExperience(((EnemyCharacter) deadCharacter).experienceForKill);

        OnLevelEnd += ui.GetComponentInChildren<GameUI>().ShowLevelEndScreen;
    }

    private void EndLevel(Character player)
    {
        OnLevelEnd?.Invoke();
    }
}