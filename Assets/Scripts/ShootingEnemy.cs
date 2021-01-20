using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    GameObject target;
    public GameObject slimeBall;
    public float fireRate = 2f; //Fire every 2 seconds
    public float speed = 1; //force of projection
    float shootingTime; //local to store last time we shot so we can make sure its done every 3s
    Vector2 targetPos;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        try
        {
            targetPos = target.transform.position;
            Fire(); //Constantly fire
        } catch (MissingReferenceException e)
        {
            //Usually happens when the player wins/loses the level
        }
    }

    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate;
            animator.SetTrigger("shoot");
            GameObject projectile = Instantiate(slimeBall, gameObject.transform.position, Quaternion.identity);
            Vector2 direction = ((Vector2)transform.position - targetPos) * -1;
            projectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed, ForceMode2D.Impulse);
        }
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
    }
}
