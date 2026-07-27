using UnityEngine;

public class PowerupManager : MonoBehaviour
{
[SerializeField] PowerupSO powerup;
PlayerController player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int layerindex = LayerMask.NameToLayer("Player");

        if (other.gameObject.layer == layerindex) {
            Debug.Log("Powerup Triggered");
            player.ActivatePowerup(powerup);
        }
    }
}