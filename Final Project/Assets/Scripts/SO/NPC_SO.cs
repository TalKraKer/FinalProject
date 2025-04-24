using UnityEngine;

[CreateAssetMenu(fileName = "NPC_SO", menuName = "NPC", order = 1)]
public class NPC_SO : ScriptableObject
{
    public string NPC_name;
    public Sprite NPC_portrait;
    public RuntimeAnimatorController NPC_Animation;
    public PlantSO plantRequest;
}
