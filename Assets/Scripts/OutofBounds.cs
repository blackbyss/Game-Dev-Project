using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutofBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player ball = collision.GetComponent<Player>();
        if(ball != null)
        {
            // fall out of bounds and u lose life, but get sent to start/checkpoint (if there are any)
            ball.resetVelocity();
            ball.transform.position = ball.spawnPoint; // current level start coordinates for player
            ball.Lives -= 1;
            Events.SetLives(ball.Lives);
        }
    }
}
