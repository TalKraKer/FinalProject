using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public bool onRegister;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onRegister = false;
    }

    void Update()
    {
        rb.velocity = moveSpeed * moveInput;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "register")
        {
            onRegister = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "register")
        {
            onRegister = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (onRegister==true)
        {
            EventManager.RegisterRealese();
        }
    }
}
