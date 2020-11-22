﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBounce : MonoBehaviour
{
    public int ExtraBounceHeight = 40;
    public int ExtraBounceTime = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Invincibility(collision));
    }

    IEnumerator Invincibility(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        collision.GetComponent<Player>().jumpHeight = ExtraBounceHeight;
        yield return new WaitForSeconds(ExtraBounceTime);
        collision.GetComponent<Player>().jumpHeight = collision.GetComponent<Player>().defaultJumpHeight;
        GameObject.Destroy(gameObject);
    }
}