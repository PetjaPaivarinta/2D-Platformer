using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changetoscene3 : MonoBehaviour
{

    public GameObject loading; 
    public bool canChangeScene = false;
    void Start()
    {
        
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Collision detected");
        canChangeScene = true;
    }

        // void onTriggerExit2D (Collider2D other)
        // {
        //     loading.SetActive(false);
        // }

        void Update() {
            if (Input.GetKeyDown(KeyCode.E) && canChangeScene == true)
        {
            loading.SetActive(true);
            Debug.Log("E key pressed");
            SceneManager.LoadScene("ThirdScene");
        }
        }
}
