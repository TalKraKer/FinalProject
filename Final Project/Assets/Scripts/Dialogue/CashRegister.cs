using UnityEngine;
public class CashRegister : MonoBehaviour
{
    private bool playerInZone = false;
    private bool npcInZone = false;

    public DialogueManager dialogueManager;
    public GameStateManager instance;

    public PlayerSelector selectedPlayer;
    public PlayerSO activePlayer;
    public NPC_SO[] npcList;

    void Start()
    {
        if (dialogueManager == null)
            dialogueManager = FindObjectOfType<DialogueManager>();

        if (instance == null)
            instance = FindObjectOfType<GameStateManager>();

        if (selectedPlayer == null)
            activePlayer = instance.selectedPlayerSO;
    }

    private void OnEnable()
    {
        NPCSpawnerScript.OnCustomerSpawned += ReadNPCData;
    }

    private void OnDisable()
    {
        NPCSpawnerScript.OnCustomerSpawned -= ReadNPCData;
    }

    private void ReadNPCData(GameObject newNPC)
    {
        if (newNPC == null)
        {
            Debug.LogError("newNPC is null in ReadNPCData!");
            return;
        }

        NPCIdentity identity = newNPC.GetComponent<NPCIdentity>();
        if(identity == null)
        {
            Debug.Log("In CashRegister script: NPCIdentity is null.");
            return;
        }

        if(identity.npcData == null)
        {
            Debug.Log("In CashRegister script: npcData is null.");
            return;
        }
        Debug.Log("NPC: " + identity.npcData.NPC_name + "is ready for dialogue.");
    }       

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInZone = true;

        if (other.CompareTag("NPC"))       
            npcInZone = true;     

        if (playerInZone && npcInZone)
        {
            NPCIdentity npcEnterd = other.GetComponent<NPCIdentity>();

            if (npcEnterd != null && npcEnterd.npcData != null)
            {
                dialogueManager.StartPlayerDialogue(activePlayer);
                dialogueManager.StartNpcDialogue(npcEnterd);
                Debug.LogError("Dialog activated");
            }
            else 
                Debug.LogError("NPC Error");                  
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInZone = false;

        if (other.CompareTag("NPC"))
            npcInZone = false;
    }
}