using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int Lives;
    public int jumpHeight;
    Rigidbody2D rigidbody2d;
    SpriteRenderer sprite;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

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
            rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
