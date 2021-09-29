using UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
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

        var ui = Instantiate(UI);
        ui.GetComponentInChildren<HUD>().SetPlayer(player);
        player.LookTarget = ui.GetComponentInChildren<CrosshairUI>().transform;

        Instantiate(Level);
        Instantiate(EnemySpawner).Player = player;
    }
}