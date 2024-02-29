using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghostlogic : MonoBehaviour
{
    public Text healthText;
    public GameObject bulletPrefab;
    public Transform mouthPosition;
    private float minTime = 1f;
    private float maxTime = 6f;
    private float bulletSpeed = 7f;
    public Transform player;
   private float healthPoints = 100;
   private float knockbackForce = 60f;

    void Start()
    {
        healthText.text = healthPoints.ToString();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
       while (true)
    {
        // Wait for a random time between minTime and maxTime
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        // Instantiate a bullet at the ghost's mouth
        GameObject bullet = Instantiate(bulletPrefab, mouthPosition.position, Quaternion.identity);

        // Shoot the bullet towards the player
        Vector2 direction = player.position - mouthPosition.position;
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }
    }

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Bullet")
    {
        healthPoints -= 25;
        healthText.text = healthPoints.ToString();

        // Get the direction from the bullet to the ghost
        Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

        // Apply a force in that direction
        GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ResetColor", 0.05f);
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    }
    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
