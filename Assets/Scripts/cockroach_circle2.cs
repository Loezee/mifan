using UnityEngine;

public class cockroach_circle2 : MonoBehaviour
{

    public float spinSpeed = 180f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        }
    }
}
