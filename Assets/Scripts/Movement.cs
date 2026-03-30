using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] TMP_Text boostText;
    [SerializeField] float steeringForce = 150f;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] float boostSpeed = 15f;
    float steeringDirection;
    float movementDirection;
    bool isBoosted = false;
    private void Start()
    {
        boostText.gameObject.SetActive(false);
    }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Booster") && !isBoosted)
        {
            isBoosted = true;
            boostText.gameObject.SetActive(true);
            movementSpeed = boostSpeed;
            Destroy(collision.gameObject, 0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            isBoosted = false;
            boostText.gameObject.SetActive(false);
            movementSpeed = regularSpeed;
    }
}
