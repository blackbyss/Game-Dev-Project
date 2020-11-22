using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorBounce : MonoBehaviour
{
    public int Boost;
    public int NrOfBoosts;
    public bool dissapearing = false;

    public void ReduceNrOfBoosts()
    {
        if (dissapearing)
        {
            if (NrOfBoosts <= 1)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                NrOfBoosts--;
            }
        }
    }

    public int GetBoost()
    {
        return Boost;
    }
}
