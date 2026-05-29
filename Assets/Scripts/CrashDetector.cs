using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;
    void OnTriggerEnter2D(Collider2D other) {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerindex) {
            crashParticles.Play();
            Invoke("ReloadScene", restartDelay);
        }
    }
    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
