using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public int tileX;
    public int tileY;

    public Vector3 destination;
    float speed = 2;

    void Start()
    {
        destination = transform.position;
    }

    void Update()
    {
        Vector3 dir = destination - transform.position;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;

        // make sure velocity doens't exeed the distance we want
        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);
        transform.Translate(velocity);
    }
    public void MoveToTile(int x, int y)
    {

    }
}
