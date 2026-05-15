using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    Vector2 MoveVector;
    void Start() {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        
        MoveVector = moveAction.ReadValue<UnityEngine.Vector2>();
        Debug.Log(MoveVector);
    }
}
