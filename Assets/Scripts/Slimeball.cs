using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeball : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collision.GetComponent<Player>().isInvincible)
            {
                collision.GetComponent<Player>().Lives--;
                Events.SetLives(Events.RequestLives() - 1);
            }
            GameObject.Destroy(gameObject);
        }
        if (collision.tag == "Platform" || collision.tag == "Traps" || collision.tag == "Boost")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
