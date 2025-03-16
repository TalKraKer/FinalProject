using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour
{

    private bool playerInZone = false;
    private bool npcInZone = false;
    public DialogueManager dialogueManager;

    void Start()
    {
        if (dialogueManager == null)
            dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInZone = true;

        if (other.CompareTag("NPC"))
            npcInZone = true;

        if (playerInZone && npcInZone)
            dialogueManager.StartDialogue();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInZone = false;

        if (other.CompareTag("NPC"))
            npcInZone = false;
    }
}
