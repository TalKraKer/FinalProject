using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject generalPanel;
    public TextMeshPro panelTitleText;
    public TextMeshPro panelBodyText;

    [SerializeField] Button settingsButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button helpButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button cancelButton;

    void Start()
    {
        //Scene storeScene = SceneManager.GetActiveScene();
        //if (button != null)
        //{
        //    button.onClick.AddListener(() => panel.SetActive(false));

        //}
        //else
        //{
        //    Debug.LogError("Button not assigned in the inspector.");
        //}

    }

    public void OnPlayClicked()
    {
        Debug.Log("Play button clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Store");
    }

    public void ActiveGeneralPanel(string type)
    {
        cancelButton.gameObject.SetActive(true);
        generalPanel.SetActive(true);

        switch (type)
        {
            case "Settings":
                panelTitleText.text = "Settings";
                panelBodyText.text = "You can mute music here";
                break;
            case "Credits":
                panelTitleText.text = "Credits";
                panelBodyText.text = "Mentor: Ella Luna Pleasance Programmers:Fany Manevich, Amir Melicson Animators: Tal Kerklies, Yarin Peled";
                break;
            case "Help":
                panelTitleText.text = "Help";
                panelBodyText.text = "--------";
                break;
            default:
                panelTitleText.text = "Panel not working";
                panelBodyText.text = "ERROR";
                break;
        }

    }

    public void OnQuitClicked()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void ClosePanelButton()
    {
        cancelButton.gameObject.SetActive(false);
        generalPanel.SetActive(false);
    }
}
