using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float timer; //creates pubilc float "timer"
    private float timer2; //creates public float "timer2"

    public AudioSource bounceSound; //creates public SudioSource "bounceSound"
    public AudioSource goalSound; //creates public SudioSource "goalSund"

    private bool inGoal = false; //creates private bool "inGoal"

    public GameObject portal1;
    public GameObject portal2;
    private bool inPortal1;
    private bool inPortal2;

    private void Start()
    {
        inPortal1 = true;
        inPortal2 = true;
    }

    void Update()  // Update is called once per frame
    {
        timer += Time.deltaTime; //when the game object is spawned, timer starts counting up

        if (timer > 0.1f) //if timer is over 1sec
        {
            GetComponent<SphereCollider>().enabled = true; //the gameobject's sphereCollider is enabled
        }

        if (timer > 10) //if timer is over 10sec
        {
            Destroy(gameObject); //destroys gameobject
        }

        if (inGoal) //if bool "inGoal" is true
        {
            timer2 += Time.deltaTime; //timer2 starts counting up

            if (timer2 > 2) //if timer2 is over 2 sec
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene
            }
        }
    }

    private void OnTriggerEnter(Collider other) //function that knows when object's collider is colliding with something
    {
        if(other.tag == "Player1") //if bullet collides with Player1
        {
            Destroy(gameObject); //Destroys bullet
        }
        

        if (other.tag == "Goal") // if bullet collides with goal
        {
            inGoal = true; //bool "inGoal" is set to true
            
            goalSound.Play(); //plays "goalSound" sound

            GetComponent<MeshRenderer>().enabled = false; // bullet mesh is diabled
            GetComponent<SphereCollider>().enabled = false; //bullet sphereCollider is disabled

        }

        if (other.tag == "box") //if bullet collides with gameobject tagged "box"
        {
            bounceSound.Play(); //plays "bounceSound" sound
        }

        if (other.tag == "Portal1" && inPortal1 == true) //if it touches portal1 and inPortal1 = true
        {
            inPortal2 = false; //set inPortal2 to false
            transform.position = portal2.transform.position; //transform new position of this object to the location of poratl2
        }

        if (other.tag == "Portal2" && inPortal2 == true) //if it touches portal2 and inPortal2 = true
        {
            inPortal1 = false; //set inPortal1 to false
            transform.position = portal1.transform.position; //transform new position of this object to the location of poratl1
        }
    }

    private void OnTriggerExit(Collider other) //create OnTriggerExit function
    {
        if (other.tag == "Portal1") //if object exits Portal1
        {
            inPortal1 = true; //inPoratl1 = true
        }
        if (other.tag == "Portal2") //if object exits Portal2
        {
            inPortal2 = true; //inPoratl2 = true
        } 
    }
}
