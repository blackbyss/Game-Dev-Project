using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBounce : MonoBehaviour
{
    public int Boost;
    public int NrOfBoosts;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (NrOfBoosts == 1)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            NrOfBoosts--;
        }
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Boost);
    }
}
