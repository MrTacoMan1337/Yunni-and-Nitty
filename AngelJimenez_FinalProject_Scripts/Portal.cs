using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{

    public GameObject otherPortal; //create public GameObject called otherPortal
    public AudioSource portalSound; //creates public AudioSource called portalSound
    public float timer; // created public float called timer

    // Start is called before the first frame update
    void Start()
    {
        timer = 0; //timer is set to 0 at the start
    }


    private void OnTriggerEnter(Collider other) //creates OnTrigger Enter function
    {
        if (other.tag == "Player1" && timer < 2) //if player1 touches the portal and the timer is less than 2 sec
        {
            portalSound.Play(); //Play portalSound
        }
    }

    private void OnTriggerStay(Collider other) //creates OnTriggerStay function
    {
        if (other.tag == "Player1" && timer < 2) //if player1 touches the portal and the timer is less than 2 sec
        {
            timer += Time.deltaTime;// time starts counting up
            

            if (timer > 2) //if time is more than 2 sec
            {

                other.transform.position = otherPortal.transform.position; //teleport player 1 to otherPortal
            }
        }

        
    }

    private void OnTriggerExit(Collider other) //creates onTriggerExit function
    {
        if(other.tag == "Player1") //if Player1 exits portal
        {
            timer = 0; //time is set back to 0
            portalSound.Pause();//portal sound paused
        }

        
    }

    
}
