using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float ScrollSpeed = 1;

    void Update()
    {
        transform.position += new Vector3(0, ScrollSpeed * Time.deltaTime, 0);
    }
}
