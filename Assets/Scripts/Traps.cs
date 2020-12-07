using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player ball = collision.GetComponent<Player>();
        if (ball != null)
        {
            ball.resetVelocity();
            ball.transform.position = ball.spawnPoint;
            ball.Lives -= 1;
            Events.SetLives(ball.Lives);
        }
    }
}
