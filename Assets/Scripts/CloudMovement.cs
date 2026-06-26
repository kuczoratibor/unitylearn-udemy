using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        gameObject.transform.position += new Vector3(-0.8f, 0, 0) * Time.deltaTime;
    }
}
