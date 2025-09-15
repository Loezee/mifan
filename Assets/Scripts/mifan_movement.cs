using UnityEngine;

public class mifan_movement : MonoBehaviour
{

    public float speed = 5f;

    bool goLeft = true;
    bool goRight = true;
    bool goUp = true;
    bool goDown = true;

    bool walkingSound = false;

    public Animator animator;

    AudioSource mySoundPlayer;
    public AudioClip dingSound;
    public AudioClip walking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //animation with movement
        Vector3 currentPos = transform.position;

        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        bool pressed = false; //is WASD pressed?
       // animator.SetBool("moving",verti!=0 ||hori!=0);
       // currentPos+=new Vector3(speed*Time.deltaTime*hori,speed*Time.deltaTime*verti,0);

/*
        //flip sprite
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1,1,1);
        }
*/
    
        if(Input.GetKey(KeyCode.W) && goUp)
        {
            //Debug.Log("PRESSED UP!");  
            currentPos.y += speed * Time.deltaTime;
            animator.SetBool("moving",verti!=0 ||hori!=0);
            pressed = true;
        }
        
        if(Input.GetKey(KeyCode.A) && goLeft)
        { 
            currentPos.x -= speed * Time.deltaTime;
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("moving",verti!=0 ||hori!=0);
            pressed = true;
        }

        if(Input.GetKey(KeyCode.S) && goDown) 
        { 
            currentPos.y -= speed * Time.deltaTime;
            animator.SetBool("moving",verti!=0 ||hori!=0);
            pressed = true;
        }

        if(Input.GetKey(KeyCode.D) && goRight)
        { 
            currentPos.x += speed * Time.deltaTime;
            transform.localScale = new Vector3(-1,1,1);
            animator.SetBool("moving",verti!=0 ||hori!=0);
            pressed = true;
        }

        transform.position = currentPos;

        animator.SetBool("moving", pressed);

        if (pressed && !walkingSound)
        {
            mySoundPlayer.clip = walking;
            mySoundPlayer.loop = true;
            mySoundPlayer.pitch = 2f; // plays faster
            mySoundPlayer.Play();
            walkingSound = true;
        }
        else if (!pressed && walkingSound)
        {
            mySoundPlayer.Stop();
            walkingSound = false;
        }

    }


    //collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger hit");
        if(collision.CompareTag("left"))
        {
            goLeft = false;
            Debug.Log("hit left border");
        }

        if(collision.CompareTag("right"))
        {
            goRight = false;
            Debug.Log("hit right border");
        }

        if(collision.CompareTag("up"))
        {
            goUp = false;
            Debug.Log("hit up border");
        }

        if(collision.CompareTag("down"))
        {
            goDown = false;
            Debug.Log("hit down border");
        }

        if(collision.CompareTag("sound"))
        {
            if(collision.gameObject.GetComponent<BloomFlower>().didDing)
            {
                mySoundPlayer.PlayOneShot(dingSound);
                collision.gameObject.GetComponent<Animator>().SetBool("doBloom", true);
                collision.gameObject.GetComponent<BloomFlower>().didDing = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("left"))
        {
            goLeft = true;
        }

        if(collision.CompareTag("right"))
        {
            goRight = true;
        }

        if(collision.CompareTag("up"))
        {
            goUp = true;
        }

        if(collision.CompareTag("down"))
        {
            goDown = true;
        }
    }

}
