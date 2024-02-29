using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyBulletDestroy : MonoBehaviour
{

private Tilemap tilemap;

     void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.tag == "Wall")
    {
        Destroy(gameObject);
    }
            }
        }