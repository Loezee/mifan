using UnityEngine;

public class cockroach_circle : MonoBehaviour
{

    public float spinSpeed = 180f; // degrees per second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime); //rotate Z
    }
}