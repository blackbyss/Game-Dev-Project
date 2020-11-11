using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int jumpHeight;
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().Lives--;
            GameObject.Destroy(gameObject);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, 0);
            rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
