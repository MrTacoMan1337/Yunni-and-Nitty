using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpace : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //if spacebar is pressed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load next scene
        }
    }
}
