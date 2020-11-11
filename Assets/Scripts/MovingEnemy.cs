using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    protected Vector3 velocity;
    Transform transform;
    public float distance;
    public float speed;
    SpriteRenderer sprite;
    Vector3 origPos;

    public void Start()
    {
        origPos = gameObject.transform.position;
        transform = GetComponent<Transform>();
        velocity = new Vector3(speed, 0, 0);
        sprite = GetComponent<SpriteRenderer>();
    }

    bool directionIsRight = false;

    void Update()
    {
        float distFromStart = transform.position.x - origPos.x;
        if (directionIsRight)
        {
            if (distFromStart > distance)
            {
                directionIsRight = false;
                sprite.flipX = false;
            }
            transform.Translate(velocity.x * Time.deltaTime, 0, 0);
        }
        else
        {
            if (distFromStart < -distance)
            {
                directionIsRight = true;
                sprite.flipX = true;
            }
            transform.Translate(-velocity.x * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().Lives--;
        GameObject.Destroy(gameObject);
    }
}
