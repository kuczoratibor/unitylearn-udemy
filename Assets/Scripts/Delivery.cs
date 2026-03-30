using UnityEngine;

public class Collisions : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package picked up!");
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package delivered!");
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, destroyDelay);
        }
    }
}
