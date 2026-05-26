using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        int layerindex = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == layerindex) {
            SceneManager.LoadScene(0);
        }
    }
}