using UnityEngine;

public class cockroach : MonoBehaviour
{

    public float dance = 0.1f;
    private float timer = 0f;
    private bool stance = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        
        if (timer >= dance)
        {
            timer = 0f;
            stance = !stance;

            Vector3 scale = transform.localScale;
            scale.x = stance ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}
