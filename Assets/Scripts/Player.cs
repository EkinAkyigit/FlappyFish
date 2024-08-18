using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;

    int angle;
    int maxAngle = 5;
    int minAngle = -10;

    public Score score;
    public GameManager gManager;
    public Sprite fishDied;
    SpriteRenderer sr;
    Animator animator;
    public Spawner spawner;
    bool isGrounded;

    [SerializeField] private AudioSource swim,hit,point;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        fishMovement();
        
    }

    private void FixedUpdate()
    {
        fishRotation();
    }

    private void fishRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
                angle += 4;
        }
        else if (rb.velocity.y < -1.5)
        {
            if (angle >= minAngle)
                angle -= 2;
        }

        if(isGrounded == false) 
            transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void fishMovement()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                rb.gravityScale = 4f;
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
                spawner.InstantiateObstacle();
                gManager.GameHasStarted();
            }
            else
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("column") && GameManager.gameOver == false)
        {
            hit.Play();
            gManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (GameManager.gameOver == false)
            {
                hit.Play();
                gManager.GameOver();
                GameOver();
            }
            else
                GameOver();
        }
            
            
    }

    private void GameOver()
    {
        isGrounded = true;
        //transform.rotation = Quaternion.Euler(0, 0, -90);
        sr.sprite = fishDied;
        animator.enabled = false;
    }
}
