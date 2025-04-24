using UnityEngine;

public class NPCInitializer : MonoBehaviour
{
    [SerializeField] private NPC_SO[] npcList;
    private void Start()
    {
        NPCIdentity identity = GetComponent<NPCIdentity>();
        if (identity == null)
        {
            Debug.LogError("In NPCInitializer: Attach this script to costumer prefab.");
            return;
        }

        int randomIndex = Random.Range(0, npcList.Length);
        identity.npcData = npcList[randomIndex];

        if (npcList == null || npcList.Length == 0)
        {
            Debug.LogWarning("NPC list is empty!");
            return;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && identity.npcData.NPC_portrait != null)
        {
            sr.sprite = identity.npcData.NPC_portrait;
        }
    }

}
