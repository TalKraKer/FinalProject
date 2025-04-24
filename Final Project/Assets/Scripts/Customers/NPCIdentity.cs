using UnityEngine;

public class NPCIdentity : MonoBehaviour
{
    public NPC_SO npcData;

    void Start()
    {
        if (npcData != null)
        {
            GetComponent<SpriteRenderer>().sprite = npcData.NPC_portrait;
            GetComponent<Animator>().runtimeAnimatorController = npcData.NPC_Animation;
        }
    }
}
