using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDown : MonoBehaviour
{
    public Rigidbody2D rb;

    public Cinemachine.CinemachineVirtualCamera cinemachineCamera;
    // Start is called before the first frame update
    void Start()
    {
   
    rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
     if (transform.position.y < 61)
        {
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.gravityScale = 1;
        }
    }
}
