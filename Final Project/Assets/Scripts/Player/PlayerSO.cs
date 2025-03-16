using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player dialogue", menuName = "Dialogue", order = 0)]
public class PlayerSO : ScriptableObject
{
    public string playerName;
    [TextArea(3, 10)]
    public string[] sentences;
}

