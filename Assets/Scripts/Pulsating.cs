using UnityEngine;

public class Pulsating : MonoBehaviour
{
    private float initialY;

    void Start()
    {
        // Store the initial y-coordinate
        initialY = transform.position.y;
    }

    void Update()
    {
        // Calculate the new position
        float yPosition = initialY + Mathf.Sin(Time.time * 2) * 0.1f; // Increase frequency and decrease amplitude

        // Apply the new position
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}