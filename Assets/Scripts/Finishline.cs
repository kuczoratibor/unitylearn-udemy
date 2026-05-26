using UnityEngine;

public class Finishline : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        int layerindex = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == layerindex) {
            Debug.Log("Player has reached the finish line!");
        }
    }
}