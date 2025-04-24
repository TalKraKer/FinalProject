using UnityEngine;

public class GameStateManager : MonoBehaviour
{
   // public static GameStateManager Instance;

    public PlayerSO selectedPlayerSO;
    public GameObject currentPlayer;

    public Transform playerSpawnPoint;
    void Start()
    {
        if (PlayerSelector.selectedPlayer != null)
        {
            currentPlayer = Instantiate(PlayerSelector.selectedPlayer, playerSpawnPoint.position, Quaternion.identity);

            PlayerBehavior playerComponent = currentPlayer.GetComponent<PlayerBehavior>();

            if (playerComponent != null)
            {
                selectedPlayerSO = PlayerSelector.selectedPlayerSO;
            }
            else
            {
                Debug.LogError("Spawned player is missing Player component!");
            }
        }
        else
        {
            Debug.LogError("Select a player prefab.");
        }
    }
}