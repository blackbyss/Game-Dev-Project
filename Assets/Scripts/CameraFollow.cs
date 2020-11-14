using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    public float speed;
    private Vector3 offset = new Vector3(8, 0, -1);

    void FixedUpdate()
    {
        Vector3 cameraPosition = character.position + offset;
        Vector3 adjustedPosition = Vector3.Lerp(transform.position, cameraPosition, speed * Time.deltaTime);
        transform.position = new Vector3(adjustedPosition.x, 5, -10);
    }
}
