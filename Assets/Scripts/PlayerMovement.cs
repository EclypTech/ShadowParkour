using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private bool isGrounded = true;
    private bool soundjump = false;
    private Vector2 jump = new Vector2(5f,100f);

    private int forceNum = 30;
    private bool maxForce=false;
    private int xForce = 6;

    private GameObject sound;
    private AudioSource soundAudioSource;
    [SerializeField] private AudioClip jumpSound;
    public Vector3 vector = new Vector3();
    private Button jumpButton;
    
    [SerializeField] private Slider forceSlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        sound = GameObject.FindGameObjectWithTag("sound");
        soundAudioSource = sound.GetComponent<AudioSource>();
        //soundAudioSource.loop = true;
        //soundAudioSource.clip = runSound;
        animator.SetBool("isGrounded", true);
        
}

    // Update is called once per frame
    void Update()
    {
        if (soundjump)
        {
            //soundAudioSource.Stop();
            
            soundjump = false;
        }

        if (Input.GetButton("Fire1") && isGrounded)
        {
            
            forceSlider.value = forceNum; 
            if(maxForce == false)
            {
                forceNum += 1;
                forceSlider.value = forceNum;
                if (forceNum == forceSlider.maxValue)
                {
                    maxForce = true;

                }
            }
            else
            {                   
                forceNum -= 1;
                forceSlider.value = forceNum;
                if (forceNum == forceSlider.minValue)
                {
                    maxForce = false;
                }
            }



        }

    }


    public void JumpExit()
    {
        if (isGrounded)
        {
            forceNum = forceNum / 5;
            rb.velocity = new Vector2(xForce, forceNum);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isGrounded = true;
            
            //soundAudioSource.Play();
            animator.SetBool("isGrounded", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
            forceNum = 20;
            forceSlider.value = forceNum;
            maxForce = false;
            soundjump = true;
            sound.GetComponent<AudioSource>().PlayOneShot(jumpSound);
            animator.SetBool("isGrounded", false);
        }
    }
}
