using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerSO playerData;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField] GameObject PlantHoldPos;

    public bool onRegister;
    public bool onPlant;
    public bool onRestock;
    public GameObject RestockStation;
    public GameObject PlantYouAreOn;
    public GameObject PlantYouAreHolding;

    void Start()
    {
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
        if (collider.gameObject.name == "CashRegister")
        {
            onRegister = true;
        }
        else if (collider.gameObject.tag == "Restock")
        {
            onRestock = true;
            RestockStation = collider.gameObject;
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
        }
        else if (collider.gameObject.tag == "Restock")
        {
            onRestock = false;
            RestockStation = null;
        }
        else if (collider.gameObject.tag == "Plant")
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
            else if (PlantYouAreHolding == null)
            {
                if (onPlant == true)
                {
                    PlantYouAreHolding = PlantYouAreOn;
                    PlantYouAreHolding.GetComponent<PlantHolding>().FollowHolder(PlantHoldPos);
                }
                else
                {
                    if (onRestock)
                    {
                        RestockStation.GetComponent<PlantRestock>().restock();
                    }
                }
            }
            else
            {
                PlantYouAreHolding.transform.position = transform.position;
                PlantYouAreHolding.GetComponent<PlantHolding>().StopFollowHolder();
                PlantYouAreHolding = null;
            }
        }
    }
}
