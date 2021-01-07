using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeball : MonoBehaviour
{

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
    }
}
