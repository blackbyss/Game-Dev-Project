using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLives : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player ball = collision.GetComponent<Player>();
        if (ball != null && collision.tag == "Player")
        {
            ball.Lives += 1;
            Events.SetLives(ball.Lives);
        }
        GameObject.Destroy(gameObject);
    }
}
