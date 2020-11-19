using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    public int InvincibilityTime = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        StartCoroutine(Invincibility(collision));
        
    }

    IEnumerator Invincibility(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        collision.GetComponent<Player>().isInvincible = true;
        collision.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(InvincibilityTime);
        collision.GetComponent<Player>().isInvincible = false;
        collision.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        GameObject.Destroy(gameObject);
    }
}
