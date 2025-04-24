// Ignore Spelling: Dialogue npc

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] GameObject PlayerDialoguePanel;
    [SerializeField] GameObject NPCDialoguePanel;
    [SerializeField] Button cancelButton;

    private PlantSO request;

    public Image portraitImage;
    public TextMeshProUGUI nameText;

    public Image[] waterDrops;
    public Sprite fullDrop;
    public Sprite emptyDrop;

    public Image[] difficultyIcons;
    public Sprite activeIcon;
    public Sprite inactiveIcon;

    public Image sunImage;
    public Sprite fullSun;
    public Sprite partialShade;
    public Sprite fullShade;

    public void DisplayPlantRequest(PlantSO request)
    {
        if(request == null)
        {
            Debug.LogWarning("PlantRequest is null.");
            return;
        }

        int waterLevel = request.waterRequirement;
        int diffLevel = request.difficultyLevel;
        int sunLevel = request.sunRequirement;

        switch (sunLevel)
        {
            case 1:
                sunImage.sprite = fullSun;
                break;
            case 2:
                sunImage.sprite = partialShade;
                break;
            case 3:
                sunImage.sprite = fullShade;
                break;
        }

        SetDifficulty(diffLevel);
        SetWater(waterLevel);
    }

    private void SetDifficulty(int level)
    {
        for (int i = 0; i < difficultyIcons.Length; i++)
        {
            difficultyIcons[i].sprite = i < level ? activeIcon : inactiveIcon;
        }
    }

    private void SetWater(int level)
    {
        for (int i = 0; i < waterDrops.Length; i++)
        {
            waterDrops[i].sprite = i < level ? fullDrop : emptyDrop;
        }
    }

    private void OnEnable()
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        dm.OnPlayerDialogue += DisplayPlayerDialogue;
        dm.OnNpcDialogue += DisplayNpcDialogue;
    }

    private void OnDisable()
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        dm.OnPlayerDialogue -= DisplayPlayerDialogue;
        dm.OnNpcDialogue -= DisplayNpcDialogue;
    }

    public void DisplayPlayerDialogue(PlayerSO player)
    {
        PlayerDialoguePanel.SetActive(true);
    }

    public void DisplayNpcDialogue(NPCIdentity npc)
    {
        PlayerDialoguePanel.SetActive(false);
        
        cancelButton.gameObject.SetActive(true);
        NPCDialoguePanel.SetActive(true);

        request = npc.npcData.plantRequest;
        Debug.LogWarning("PlantRequest: diff:"+ request.difficultyLevel + "water:" + request.waterRequirement);
        DisplayPlantRequest(request);

        portraitImage.sprite = npc.npcData.NPC_portrait;
        nameText.text = npc.npcData.NPC_name;
    }

    public void EndDialogue()
    {
        cancelButton.gameObject.SetActive(false);
        PlayerDialoguePanel.SetActive(false);
        NPCDialoguePanel.SetActive(false);
    }
}
