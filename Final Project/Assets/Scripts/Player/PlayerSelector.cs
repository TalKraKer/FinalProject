using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public static GameObject selectedPlayer;
    public static PlayerSO selectedPlayerSO;

    public static void SelectPlayer(GameObject playerPrefab, PlayerSO playerData)
    {
        selectedPlayer = playerPrefab;
        selectedPlayerSO = playerData;
    }
}
