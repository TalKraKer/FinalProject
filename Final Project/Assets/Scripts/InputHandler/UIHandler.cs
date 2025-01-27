using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject helpPanel;

    [SerializeField] Button settingsButton;
    [SerializeField] Button CreditsButton;
    [SerializeField] Button helpButton;

    void Start()
    {
        Scene storeScene = SceneManager.GetActiveScene();
        //if (button != null)
        //{
        //    button.onClick.AddListener(() => panel.SetActive(false));

        //}
        //else
        //{
        //    Debug.LogError("Button not assigned in the inspector.");
        //}
        
    }

    public void onPlayPerformed()
    {
        Debug.Log("Play button clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Store");
    }
}
