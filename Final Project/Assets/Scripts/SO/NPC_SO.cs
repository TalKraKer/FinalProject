using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC", order = 1)]
public class NPC_SO : ScriptableObject
{
    public string NPC_name;
    public Sprite NPC_portrait;

    [TextArea(3, 10)]
    public string[] sentences;
}
