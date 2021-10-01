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

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        var player = Instantiate(Player);

        var playerCamera = Instantiate(Camera);
        playerCamera.SetTarget(player.transform);

        var enemySpawner = Instantiate(EnemySpawner);
        enemySpawner.Player = player;

        var ui = Instantiate(UI);
        ui.GetComponentInChildren<HUD>().SetPlayer(player);
        OnLevelEnd += ui.GetComponentInChildren<GameUI>().ShowLevelEndScreen;

        enemySpawner.OnEnemySpawned += ui.GetComponentInChildren<EnemyHealthBarManager>().DrawHealthBarForEnemy;

        player.LookTarget = ui.GetComponentInChildren<CrosshairUI>().transform;
        player.OnDie += EndLevel;

        Instantiate(Level);
    }

    private void EndLevel(Character player)
    {
        OnLevelEnd?.Invoke();
    }
}