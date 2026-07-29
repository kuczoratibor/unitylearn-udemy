using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem winParticles;
    [SerializeField] ScoreManager scoreManager;
    bool triggered = false;
    void OnTriggerEnter2D(Collider2D other) {
        if (triggered) { return; }
        int layerindex = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == layerindex) {
            triggered = true;
            winParticles.Play();
            scoreManager.AddScore(500);
            Invoke("ReloadScene", restartDelay);
        }
    }
    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}