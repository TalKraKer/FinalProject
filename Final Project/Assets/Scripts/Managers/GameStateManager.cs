using UnityEngine;
using System;
using Assets.Scripts.Managers;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public event Action<GameState> OnGameStateChange; 

    public static GameStateManager Instance;   
    public GameStateChannel gameStateChannel;

    public Input playerInput;
    public PlayerSO selectedPlayerSO;
    public GameObject currentPlayer;

    public GameState currentState;
    public GameState CurrentGameState => currentState;

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
        
        SetState(currentState);
        OnGameStateChange += HandleGameStateChange;
    }

    public void SetCurrentState(GameState state)
    {
        currentState = state;
        if (gameStateChannel != null)
        {
            gameStateChannel.StateEntered(state);
        }
        else
        {
            Debug.LogError("GameStateChannel is not assigned!");
        }
    }

    private void HandleGameStateChange(GameState newState)
    {
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component not assigned.");
            return;
        }

        switch (newState)
        {
            case GameState.Playing:
                SwitchToPlayerInput();
                Debug.Log("Switched to Player action map.");
                break;

            case GameState.MainMenu:
                SwitchToUIInput();
                Debug.Log("Switched to UI action map.");
                break;

            case GameState.UI:
                SwitchToUIInput();
                Debug.Log("Switched to UI action map.");
                break;

            case GameState.Book:
                SwitchToPlayerInput();
                Debug.Log("Switched to Player action map.");
                break;
            case GameState.Dialogue:
                SwitchToUIInput();
                break;
            case GameState.EndGame:
                SwitchToUIInput();
                break;

            default:
                Debug.LogWarning(newState);
                break;
        }
    }

    void SwitchToUIInput()
    {
        playerInput.UI.Enable();
        playerInput.Player.Disable();
    }

    void SwitchToPlayerInput()
    {
        playerInput.UI.Disable();
        playerInput.Player.Enable();
    }
    public void ChangeState(GameState newState)
    {
        if (gameStateChannel != null)
        {
            gameStateChannel.StateExited(currentState);
            currentState = newState;
            gameStateChannel.StateEntered(currentState);
        }
        else
        {
            Debug.LogError("GameStateChannel is not assigned!");
        }
    }

    public void SetState(GameState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            OnGameStateChange?.Invoke(currentState);
            Debug.Log("State changed to: " + currentState);
        }
    }

    private void BookOpened()
    {
        if (currentState == GameState.Book)
        {
            currentState = GameState.Playing;
            Time.timeScale = 1f;
        }
        else
        {
            currentState = GameState.Book;
            Time.timeScale = 0f;
        }

        OnGameStateChange?.Invoke(currentState);
    }

    public void TransitionToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Transitioning to: " + sceneName);
    } 
}