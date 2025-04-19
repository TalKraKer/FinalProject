using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public InputChannel inputChannel;
    private Input inputActions;

    private void Awake()
    {
        inputActions = new Input();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

        inputActions.Player.Interact.performed += OnInteract;

        inputActions.Enable();
    }

    private void OnDestroy()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        inputChannel.HandleMove(context);

        Debug.Log("InputReader: Movement " + direction);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        inputChannel.RaiseInteract();
        Debug.Log("InputReader: Interact pressed (E)");
    } 
}
