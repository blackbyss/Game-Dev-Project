using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 12;
    public int Lives = 5;
    public float defaultJumpHeight = 35;
    public int defaultGravity = 8;
    [HideInInspector] public float jumpHeight;
    Rigidbody2D rigidbody2d;
    SpriteRenderer sprite;
    public Vector3 spawnPoint;
    public bool isInvincible = false;
    Animator animator;
    bool levelComplete = false;
    public RuntimeAnimatorController[] controllers;

    public AudioSource VictorySound;
    public AudioSource CheckpointSound;
    public AudioClipGroup BounceAudio;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jumpHeight = defaultJumpHeight;
        spawnPoint = gameObject.transform.position;
        rigidbody2d.gravityScale = defaultGravity;
        animator = GetComponent<Animator>();
    }

    string currentBall = "default";
    bool doubleJumped = false;

    void FixedUpdate()
    {
        if (!levelComplete)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += (Vector3) new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0);
                sprite.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += (Vector3)new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0);
                sprite.flipX = false;
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                resetVelocity();
                currentBall = "default";
                animator.runtimeAnimatorController = controllers[0];
                jumpHeight = defaultJumpHeight;
                rigidbody2d.gravityScale = defaultGravity;
                transform.localScale = new Vector3(10f, 10f, 1f);
                sprite.flipY = false;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                resetVelocity();
                currentBall = "doubleBounce";
                animator.runtimeAnimatorController = controllers[1];
                jumpHeight = defaultJumpHeight * 0.7f; //Multiplied value is sketchy
                rigidbody2d.gravityScale = defaultGravity;
                transform.localScale = new Vector3(10f, 10f, 1f);
                sprite.flipY = false;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                resetVelocity();
                currentBall = "balloon";
                animator.runtimeAnimatorController = controllers[2];
                jumpHeight = defaultJumpHeight * 0.3f;
                rigidbody2d.gravityScale = 1;
                transform.localScale = new Vector3(15f, 15f, 1f);
                sprite.flipY = false;
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                resetVelocity();
                currentBall = "reverseGravity";
                animator.runtimeAnimatorController = controllers[3];
                jumpHeight = -defaultJumpHeight;
                rigidbody2d.gravityScale = -defaultGravity;
                transform.localScale = new Vector3(10f, 10f, 1f);
                sprite.flipY = true;
            }
            if (currentBall == "doubleBounce")
            {
                if (Input.GetKey(KeyCode.Space) && !doubleJumped)
                {
                    animator.SetTrigger("doubleBounce");
                    rigidbody2d.velocity = new Vector2(0, 0);
                    rigidbody2d.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    doubleJumped = true;
                }
            }
            if (Lives <= 0)
            {
                GameOver();
            }
        }
    }

    public void resetVelocity()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
    }
    void GameOver()
    {
        Events.EndLevel(false);
        GameObject.Destroy(gameObject);
        //SceneManager.LoadScene("SampleScene"); // for testing purposes

    }
    public void gotHit()
    {
        if (!isInvincible)
        {
            Lives -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            animator.SetTrigger("takeOff");
            BounceAudio.Play();
            rigidbody2d.velocity = new Vector2(0, 0);
            rigidbody2d.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            doubleJumped = false;
        }
        if (collision.tag == "Boost")
        {
            animator.SetTrigger("takeOff");
            BounceAudio.Play();
            rigidbody2d.velocity = new Vector2(0, 0);
            int Boost = collision.GetComponent<FloorBounce>().GetBoost();
            rigidbody2d.AddForce(transform.up * Boost, ForceMode2D.Impulse);
            collision.GetComponent<FloorBounce>().ReduceNrOfBoosts();
            doubleJumped = false;
        }
        if (collision.tag == "Finish") // win
        {
            if (!levelComplete)
            {
                resetVelocity();
                VictorySound.Play();
                Events.EndLevel(true);
                //SceneManager.LoadScene("SampleScene");
                levelComplete = true;
            }
        }
        if(collision.tag == "Checkpoint")
        {
            CheckpointSound.Play();
            spawnPoint = collision.transform.position;
            spawnPoint.y += 4;
        }
    }
}
