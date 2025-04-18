using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public InputChannel inputChannel;
    private Input inputActions;

    private void Awake()
    {
        inputActions = new Input();
        inputActions.Player.Move.performed += ctx => inputChannel.HandleMove(ctx);
        inputActions.Player.Move.canceled += ctx => inputChannel.HandleMove(ctx);

        inputActions.Enable();
    }

    private void OnDestroy()
    {
        inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            inputChannel.HandleMove(context);
            Debug.Log("InputReader: Movement " + direction);
        }
    }
}
