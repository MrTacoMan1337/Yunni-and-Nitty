using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float timer; //creates pubilc float "timer"
    public AudioSource bounceSound; //creates public SudioSource "bounceSound"
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //when the game object is spawned, timer starts counting up

        if (timer > 10) //if timer is over 10sec
        {
            Destroy(gameObject); //destroys gameobject
        }
    }

    private void OnTriggerEnter(Collider other) //function that knows when object's collider is colliding with something
    {
        if (other.tag == "Player1") //if bullet collides with Player1
        {
            Destroy(gameObject); //Destroys bullet
        }
        if (other.tag == "Player2") //if bullet collides with Player1
        {
            Destroy(gameObject); //Destroys bullet
        }


        if (other.tag == "box") //if bullet collides with gameobject tagged "box"
        {
            bounceSound.Play(); //plays "bounceSound" sound
        }
        
    }
}
