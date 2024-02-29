using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed = 3f;
    private bool moveRight = true;
    public float distance = 5f;
    private float initialPosition;
    private float finalPosition;
    void Start()
    {
        initialPosition = transform.position.x;
    }

    private void Update () {
        if (transform.position.x > initialPosition + distance)
        {
            moveRight = false;
        }
        if (transform.position.x < initialPosition)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    
}