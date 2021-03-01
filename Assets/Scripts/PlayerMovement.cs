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
    private int num = 4;
    private int forceNum = 0;
    private bool maxForce=false;

    private GameObject sound;
    private AudioSource soundAudioSource;
    [SerializeField] private AudioClip jumpSound;

    

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
        
}

    // Update is called once per frame
    void Update()
    {
        if (soundjump)
        {
            //soundAudioSource.Stop();
            //sound.GetComponent<AudioSource>().PlayOneShot(jumpSound);
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

        if (Input.GetButtonUp("Fire1"))
        {
            forceNum = forceNum / 10;
            rb.velocity = new Vector2(forceNum, forceNum);
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
            forceNum = 0;
            forceSlider.value = forceNum;
            isGrounded = false;
            soundjump = true;
            animator.SetBool("isGrounded", false);
        }
    }
}
