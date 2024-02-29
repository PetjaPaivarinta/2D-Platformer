using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthFollowGhost : MonoBehaviour
{
     public GameObject Ghost;
    public Vector3 offset = new Vector3(0f, 1f, 0f); // Adjust this offset as needed

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Ghost != null)
        {
            transform.position = Ghost.transform.position + offset;
        }
    }
}
