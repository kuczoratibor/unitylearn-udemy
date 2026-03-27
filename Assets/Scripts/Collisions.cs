using UnityEngine;

public class Collisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision happened.");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Trigger happened.");
    }
}
