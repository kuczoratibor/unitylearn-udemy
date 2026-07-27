using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 11f;
    [SerializeField] float boostSpeed = 13f;
    float totalRotation = 0f;
    float previousRotation = 0f;
    int flips = 0;
    InputAction moveAction;
    Vector2 MoveVector;
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;
    bool canControlPlayer = true;
    void Start() {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }
    void RotatePlayer() {
        MoveVector = moveAction.ReadValue<Vector2>();
        if (MoveVector.x < 0) {
            rb.AddTorque(torqueAmount);
        }
        else if (MoveVector.x > 0) {
            rb.AddTorque(-torqueAmount);
        }
    }
    void BoostPlayer() {
        if (MoveVector.y > 0) {
            surfaceEffector2D.speed = boostSpeed;
        }
        else {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
    void CalculateFlips() {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        previousRotation = currentRotation;

        if (totalRotation > 340 || totalRotation < -340) {
            flips++;
            scoreManager.AddScore(100);
            totalRotation = 0f;
        }

        Debug.Log($"Flips: {flips}");
    }
    public void DisablePlayerControl()
    {
        canControlPlayer = false;
    }
}