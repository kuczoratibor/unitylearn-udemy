using UnityEngine;

public class PowerupManager : MonoBehaviour
{
[SerializeField] PowerupSO powerup;
PlayerController player;
SpriteRenderer spriteRenderer;
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int layerindex = LayerMask.NameToLayer("Player");

        if (other.gameObject.layer == layerindex && spriteRenderer.enabled) {
            spriteRenderer.enabled = false;
            Debug.Log("Powerup Triggered");
            player.ActivatePowerup(powerup);
        }
    }
}