using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject door; //creates public GameObject called door
    public AudioSource doorSound; //creates public AudioSource called doorSound
    private void OnTriggerEnter(Collider other) //creates OnTriggerEnter funcion
    {
        if (other.tag == "Player2") // if player 2 is on pressure plate
        {
            doorSound.Play(); //play doorSound
            transform.position = transform.position + new Vector3(0, -0.05f, 0); //transform postion to y = -0.5

            door.GetComponent<Animator>().SetTrigger("OpenDoor"); //do trigger animation on door called "OpenDoor"

        }

    }

    private void OnTriggerExit(Collider other) //creats OnTriggerExit function
    {
        if (other.tag == "Player2") //if Player2 exits the pressure plate
        {
            transform.position = transform.position + new Vector3(0, 0.05f, 0); //transform position back to y = 0.05
            door.GetComponent<Animator>().SetTrigger("CloseDoor"); //do trigger animation on door called "CloseDoor"
        }
    }
}
