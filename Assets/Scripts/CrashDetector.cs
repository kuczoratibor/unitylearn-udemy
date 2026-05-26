using UnityEngine;

public class CrashDetector : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other) {
    int layerindex = LayerMask.NameToLayer("Floor");
    if (other.gameObject.layer == layerindex) {
        Debug.Log("Player has crashed!");
    }
    }
}
