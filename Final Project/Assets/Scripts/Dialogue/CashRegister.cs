// Ignore Spelling: dialogue
using UnityEngine;
using System.Collections;

public class CashRegister : MonoBehaviour
{
    private bool playerInZone = false;
    private bool npcInZone = false;

    public DialogueManager dialogueManager;
    public GameStateManager instance;
    public PlayerSO playerSO;
    public NPC_SO[] NPCToTalkTo;

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
        {
            npcInZone = true;
            DialogueUI ui = FindObjectOfType<DialogueUI>();
            PlantRequest request = other.GetComponent<PlantRequest>();
            if (request != null && ui != null)
            {
                ui.DisplayPlantRequest(request);
            }
            else
            {
                Debug.LogWarning("Add PlantRequest component or DialogueUI.");
            }
        }
            

        if (playerInZone && npcInZone)
            StartCoroutine(Ready4Dialogue());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInZone = false;

        if (other.CompareTag("NPC"))
            npcInZone = false;
    }

    private IEnumerator Ready4Dialogue()
    {
        dialogueManager.StartDialogue(instance.selectedPlayerSO);

        yield return new WaitForSeconds(1.5f);

        dialogueManager.StartDialogue(NPCToTalkTo[0]);
    }

    }
