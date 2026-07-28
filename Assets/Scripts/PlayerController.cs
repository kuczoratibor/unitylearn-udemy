using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 8f;
    [SerializeField] float boostSpeed = 10f;
    float totalRotation = 0f;
    float previousRotation = 0f;
    int activePowerupCount = 0;
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
            scoreManager.AddScore(100);
            totalRotation = 0f;
        }
    }
    public void DisablePlayerControl()
    {
        canControlPlayer = false;
    }
    void ResetSpeed() {
        activePowerupCount--;
        baseSpeed = 8f;
        boostSpeed = 10f;
        if (activePowerupCount == 0) {
            snowTrail.startColor = Color.white;
        }
    }
    void ResetTorque() {
        activePowerupCount--;
        torqueAmount = 7f;
        if (activePowerupCount == 0) {
            snowTrail.startColor = Color.white;
        }
    }
    public void ActivatePowerup(PowerupSO powerup)
    {
        activePowerupCount++;
        if (powerup.GetPowerupType() == "speed") {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
            snowTrail.startColor = Color.lightSkyBlue;
            Invoke("ResetSpeed", powerup.GetDuration());
        }
        if (powerup.GetPowerupType() == "torque") {
            torqueAmount += powerup.GetValueChange();
            snowTrail.startColor = Color.orange;
            Invoke("ResetTorque", powerup.GetDuration());
        }
    }
}