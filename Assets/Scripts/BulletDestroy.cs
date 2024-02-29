using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

   void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
    {
        Destroy(gameObject);
    }

    if (collision.gameObject.tag == "EnemyBullet")
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
            }
        }
