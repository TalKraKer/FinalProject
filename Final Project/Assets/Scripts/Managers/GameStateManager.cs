using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    //public GameState currentGameState { get; private set; }

    public PlayerSO selectedPlayerSO;
    private GameObject currentPlayer;

    public Transform playerSpawnPoint;
    void Start()
    {

        if (PlayerSelector.selectedPlayer != null)
        {
            currentPlayer = Instantiate(PlayerSelector.selectedPlayer, playerSpawnPoint.position, Quaternion.identity);

            PlayerBehavior playerComponent = currentPlayer.GetComponent<PlayerBehavior>();
            if (playerComponent != null)
            {
               // GameObject player = Instantiate(PlayerSelector.selectedPlayer, playerSpawnPoint.position, Quaternion.identity);
               // selectedPlayerSO = playerComponent.playerData;
                PlayerSO activePlayerSO = PlayerSelector.selectedPlayerSO;
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


