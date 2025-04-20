// Ignore Spelling: Dialogue

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public Image portraitImage;
    public TextMeshProUGUI nameText;

    public Image[] waterDrops;
    public Sprite fullDrop;
    public Sprite emptyDrop;

    public Image[] difficultyIcons;
    public Sprite activeIcon;
    public Sprite inactiveIcon;

   // public SunType sunRequirement;
    public Image sunImage;
    public Sprite fullSun;
    public Sprite partialShade;
    public Sprite fullShade;

    public void DisplayPlantRequest(PlantRequest request)
    {
        switch (request.sunRequirement)
        {
            case SunRequirement.FullSun:
                sunImage.sprite = fullSun;
                break;
            case SunRequirement.PartialShade:
                sunImage.sprite = partialShade;
                break;
            case SunRequirement.FullShade:
                sunImage.sprite = fullShade;
                break;
        }

        for (int i = 0; i < waterDrops.Length; i++)
        {
            waterDrops[i].sprite = i < request.waterRequirement ? fullDrop : emptyDrop;
        }

        for (int i = 0; i < difficultyIcons.Length; i++)
        {
            difficultyIcons[i].sprite = i < request.difficultyRequirement ? activeIcon : inactiveIcon;
        }

    }

    private void OnEnable()
    {
        DialogueManager.Instance.OnDialogueStart += DisplayDialogue;
    }

    private void OnDisable()
    {
        DialogueManager.Instance.OnDialogueStart -= DisplayDialogue;
    }

    public void DisplayDialogue(PlayerSO player)
    {
        portraitImage.sprite = player.playerPortrait;
        nameText.text = player.playerName;
    }
}
