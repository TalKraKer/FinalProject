using UnityEngine;
using UnityEngine.InputSystem;

public class BookUI : MonoBehaviour
{
    public bool CurrentActive = false;
    [SerializeField] GameObject uiBookElement;

    public void ChangeBookState(InputAction.CallbackContext context)
    {
      //  CurrentActive = !CurrentActive;
       // uiBookElement.SetActive(CurrentActive);
    }
}
