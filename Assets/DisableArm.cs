using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableArm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Hit wall");
            if (GetComponent<HingeJoint2D>().enabled == false)
            {
                Destroy(gameObject);
            }

        }
    }
}
