using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerSO playerData;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public bool onRegister;
    public bool onPlant;
    public GameObject PlantYouAreOn;
    public List<GameObject> PlantsYouAreHolding;

    void Start()
    {
        PlantsYouAreHolding = new List<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        onRegister = false;
        onPlant = false;
    }

    void FixedUpdate()
    {
        rb.velocity = moveSpeed * moveInput;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "CashRegister")
        {
            onRegister = true;
        }
        else if (collider.gameObject.tag == "Plant")
        {
            onPlant = true;
            PlantYouAreOn = collider.gameObject;
        }    
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "CashRegister")
        {
            onRegister = false;
        }else if (collider.gameObject.tag == "Plant")
        {
            onPlant = false;
            PlantYouAreOn = null;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move input: " + moveInput);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (onRegister == true)
            {
                NPCEventManager.RegisterRealese();
            }
            else if (onPlant == true)
            {
                PlantsYouAreHolding.Add(PlantYouAreOn);
                PlantYouAreOn.SetActive(false);
            }
            else
            {
                float tempOffset = 0;
                foreach (GameObject plant in PlantsYouAreHolding)
                {
                    plant.SetActive(true);
                    plant.transform.position = new Vector3(transform.position.x, transform.position.y + tempOffset, transform.position.z);
                    tempOffset += 0.5f;
                }
                PlantsYouAreHolding.Clear();
            }
        }
    }
}
