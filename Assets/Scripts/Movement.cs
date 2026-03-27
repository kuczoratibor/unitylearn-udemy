using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float steeringForce = 150f;
    [SerializeField] float movementSpeed = 10f;
    float steeringDirection;
    float movementDirection;

    void Update()
    {
        steeringDirection = 0f;
        movementDirection = 0f;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            steeringDirection = 1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            steeringDirection = -1f;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            movementDirection = 1f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            movementDirection = -1f;
        }
        transform.Rotate(0, 0, steeringDirection * steeringForce * Time.deltaTime);
        transform.Translate(new Vector3(0, movementDirection * movementSpeed * Time.deltaTime, 0));
    }
}
