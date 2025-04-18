using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookUI : MonoBehaviour
{
    public bool CurrentActive = false;
    [SerializeField] GameObject uiBookElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBookState(InputAction.CallbackContext context)
    {
        CurrentActive = !CurrentActive;
        uiBookElement.SetActive(CurrentActive);
    }
}
