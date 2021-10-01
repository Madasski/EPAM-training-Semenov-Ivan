using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject EndLevelScreen;
    
    public void ShowLevelEndScreen()
    {
        EndLevelScreen.SetActive(true);
    }
}