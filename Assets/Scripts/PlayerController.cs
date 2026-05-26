using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    InputAction moveAction;
    Vector2 MoveVector;
    Rigidbody2D rb;
    void Start() {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        MoveVector = moveAction.ReadValue<Vector2>();
        if (MoveVector.x < 0) {
            rb.AddTorque(torqueAmount);
        }
        else if (MoveVector.x > 0) {
            rb.AddTorque(-torqueAmount);
        }
    }
}