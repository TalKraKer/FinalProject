using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueBubble;
    public PlayerSO[] playerSO;

    void Start()
    {
        dialogueBubble.SetActive(false);
    }

    public void StartDialogue( )
    {
        Debug.Log("Start");
        dialogueBubble.SetActive(true);

    }


}
