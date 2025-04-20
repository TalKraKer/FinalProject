// Ignore Spelling: Dialogue
using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerDialoguePanel;
    [SerializeField] GameObject NPCDialoguePanel;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image portraitImage;

    public static DialogueManager Instance;
    public event Action<PlayerSO> OnDialogueStart;

    public PlayerSO[] playerSO;
    private Queue<string> currentSentences;

    void Start()
    {
        // dialogueUI.DisplayDialogue(playerSO[0]);
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartDialogue(PlayerSO player)
    {
        PlayerDialoguePanel.SetActive(true);
        nameText.text = player.playerName;
        portraitImage.sprite = player.playerPortrait;
        currentSentences = new Queue<string>(player.sentences);
        ShowNextSentence();
        Debug.Log(nameText + "is talking to: " + player.playerName);
        OnDialogueStart?.Invoke(player);
    }

    public void StartDialogue(NPC_SO npc)
    {
        NPCDialoguePanel.SetActive(true);
        nameText.text = npc.NPC_name;
        portraitImage.sprite = npc.NPC_portrait;
        currentSentences = new Queue<string>(npc.sentences);
        ShowNextSentence();
    }

    private void ShowNextSentence()
    {
        if (currentSentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = currentSentences.Dequeue();
        Debug.Log("Next Sentence: " + sentence);
    }

    private void EndDialogue()
    {
        PlayerDialoguePanel.SetActive(false);
     //   NPCDialoguePanel.SetActive(false);
    }
}
