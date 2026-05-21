using UnityEngine;

public class Finishline : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision detected.");
    }
}