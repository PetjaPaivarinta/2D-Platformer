using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlip : MonoBehaviour
{

    void Update()
{
    // Get the mouse position in world coordinates
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // Calculate the direction from the gun to the mouse
    Vector2 direction = mousePosition - (Vector2)transform.position;

    // Calculate the angle of the direction
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // Rotate the gun to face the mouse
    transform.rotation = Quaternion.Euler(0, 0, angle);
}
}
