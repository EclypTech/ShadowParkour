using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private bool isGrounded = true;
    private bool soundjump = false;
    private Vector2 jump = new Vector2(5f,100f);
    private int num = 4;

    private GameObject sound;
    private AudioSource soundAudioSource;
    [SerializeField] private AudioClip runSound, jumpSound;

    [SerializeField] private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = new Vector2(speed, 0);
        sound = GameObject.FindGameObjectWithTag("sound");
        soundAudioSource = sound.GetComponent<AudioSource>();
        soundAudioSource.loop = true;
        soundAudioSource.clip = runSound;
        
}

    // Update is called once per frame
    void Update()
    {
        if (soundjump)
        {
            soundAudioSource.Stop();
            sound.GetComponent<AudioSource>().PlayOneShot(jumpSound);
            soundjump = false;
        }

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.velocity = new Vector2(speed, 9f);
        }

        if (Input.GetMouseButtonDown(0) && !isGrounded)
        {
            rb.velocity = new Vector2(speed , -10f);
        }

        GameObject findcam = GameObject.Find("Main Camera");
        Score findscore = findcam.GetComponent<Score>();

        if (Mathf.RoundToInt(findscore.totalScore) == num)
        {
            num += 4;
            speed += 0.1f;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isGrounded = true;
            soundAudioSource.Play();
            animator.SetBool("isGrounded", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
            soundjump = true;
            animator.SetBool("isGrounded", false);
        }
    }
}
