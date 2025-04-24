using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    public event Action<PlayerSO> OnPlayerDialogue;
    public event Action<NPCIdentity> OnNpcDialogue;

    public void StartPlayerDialogue(PlayerSO player)
    {
        Debug.Log(player.playerName + "is talking.");
        OnPlayerDialogue?.Invoke(player);
    }

    public void StartNpcDialogue(NPCIdentity npc)
    {
        
        Debug.Log(npc.npcData.NPC_name + "is talking.");
        OnNpcDialogue?.Invoke(npc);
    }
}