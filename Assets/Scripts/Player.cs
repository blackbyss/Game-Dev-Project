using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 12;
    public int Lives = 3;
    public float defaultJumpHeight = 25;
    float jumpHeight;
    Rigidbody2D rigidbody2d;
    SpriteRenderer sprite;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jumpHeight = defaultJumpHeight;
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
        if (Input.GetKey(KeyCode.B))
        {
            currentBall = "doubleBounce";
            jumpHeight = defaultJumpHeight * 0.7f; //Mutiplied value is sketchy
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentBall = "default";
            jumpHeight = defaultJumpHeight;
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

    void GameOver()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            rigidbody2d.velocity = new Vector2(0, 0);
            rigidbody2d.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            doubleJumped = false;
        }
    }
}
