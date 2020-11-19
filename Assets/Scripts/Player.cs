using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 12;
    public int Lives = 3;
    public float defaultJumpHeight = 35;
    public int defaultGravity = 8;
    [HideInInspector] public float jumpHeight;
    Rigidbody2D rigidbody2d;
    SpriteRenderer sprite;
    public Vector3 spawnPoint;
    public bool isInvincible = false;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jumpHeight = defaultJumpHeight;
        spawnPoint = gameObject.transform.position;
        rigidbody2d.gravityScale = defaultGravity;
    }

    string currentBall = "default";
    bool doubleJumped = false;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(speed * -1, rigidbody2d.velocity.y);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentBall = "doubleBounce";
            jumpHeight = defaultJumpHeight * 0.7f; //Multiplied value is sketchy
        }
        /*
        if (Input.GetKey(KeyCode.S))
        {
            currentBall = "balloon";
            jumpHeight = defaultJumpHeight * 0.5f;
            rigidbody2d.gravityScale = 1;
            transform.localScale = new Vector3(15f, 15f, 1f);
        }
        */
        if (Input.GetKey(KeyCode.D))
        {
            currentBall = "default";
            jumpHeight = defaultJumpHeight;
            rigidbody2d.gravityScale = defaultGravity;
            transform.localScale = new Vector3(10f, 10f, 1f);
        }
        if (currentBall == "doubleBounce")
        {
            if (Input.GetKey(KeyCode.Space) && !doubleJumped)
            {
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

    public void resetVelocity()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
    }
    void GameOver()
    {
        //GameObject.Destroy(gameObject);
        Events.EndLevel(false);
        //SceneManager.LoadScene("SampleScene"); // for testing purposes

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            rigidbody2d.velocity = new Vector2(0, 0);
            rigidbody2d.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            doubleJumped = false;
        }
        if (collision.tag == "Boost")
        {
            rigidbody2d.velocity = new Vector2(0, 0);
            int Boost = collision.GetComponent<FloorBounce>().GetBoost();
            rigidbody2d.AddForce(transform.up * Boost, ForceMode2D.Impulse);
            collision.GetComponent<FloorBounce>().ReduceNrOfBoosts();
            doubleJumped = false;
        }
        if (collision.tag == "Finish") // win
        {
            Events.EndLevel(true);
            //SceneManager.LoadScene("SampleScene");
        }
        if(collision.tag == "Checkpoint")
        {
            spawnPoint = collision.transform.position;
            spawnPoint.y += 4;
        }
    }
}
