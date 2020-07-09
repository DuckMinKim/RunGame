using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public Text MyScore;
    public float score;
    public AudioClip deathClip;
    public float jumpForce = 700f; 

    private int jumpCount = 0; 
    private bool isGrounded = false; 
    private bool isDead = false; 

    private Rigidbody2D rb2; 
    private Animator animator; 
    private AudioSource playerAudio;

    public float radio;
    public LayerMask Ground;
    public Vector3 offset;

    void Start()
    {
        score = 0;
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        score += Time.deltaTime;
        MyScore.text = "Score : " + (int)score;
        isGrounded = Physics2D.OverlapCircle(transform.position + offset, radio, Ground);

        if (isDead)
            return;

        if (Input.GetMouseButtonDown(0) && jumpCount < 1)
        {
            jumpCount++;
            rb2.velocity = Vector2.zero;
            rb2.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && rb2.velocity.y > 0)
            rb2.velocity = rb2.velocity * 0.5f;

        animator.SetBool("Grounded", isGrounded);

        if (isGrounded)
            jumpCount = 0;

    }

    void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();
        rb2.velocity = Vector2.zero;
        isDead = true;
    }
   
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position+ offset, radio);
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

   //void OnCollisionEnter2D(Collision2D collision) {
   //    // 바닥에 닿았음을 감지하는 처리
   //}

   //void OnCollisionExit2D(Collision2D collision) {
   //    // 바닥에서 벗어났음을 감지하는 처리
   //}
   
}