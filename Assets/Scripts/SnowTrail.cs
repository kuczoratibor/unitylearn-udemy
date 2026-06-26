using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailParticles;
    private void OnCollisionEnter2D(Collision2D other)
    {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerindex)
        {
            snowTrailParticles.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        int layerindex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerindex)
        {
            snowTrailParticles.Stop();
        }
    }
}
