using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSlime : MonoBehaviour
{

    private float slimeHealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (slimeHealth <= 0)
            {
                Destroy(gameObject);
                transform.parent.GetComponent<HingeJoint2D>().enabled = false;
            }
            slimeHealth--;
        }
    }
}
