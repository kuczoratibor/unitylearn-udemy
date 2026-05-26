using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerindex) {
                SceneManager.LoadScene(0);
        }
    }
}
