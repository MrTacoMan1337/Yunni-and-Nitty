using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public float speed = 7f; //creates public float "speed" and sets it to 7f
    public float speedr = 100; //creates public float "speedr" and sets it to 100

    public bool hasShot; //creates public bool "hasShot"

    public float countDown; //creates float variable 'countDown'
    public float coolDown = 2; //creates float variable 'coolDown 

    public AudioSource place;//creates public AudioSource "place"
    public AudioSource fall; //creates public AudioSource "fall"
    public AudioSource electricity; //creates public AudioSource "electricity"
    public AudioSource gettingShot; //creates public AudioSource "gettingShot"
    public AudioSource burning; //creates public AudioSource "burning"
    public AudioSource spikeSound; //creates public AudioSource "spikeSound"

    public float health = 100f; //create public float called health and set it to 100f
    public Slider healthBar; //create Slider names healthBar
    public float damagetimer; //creates public float named "damagetimer"
    


    void Start() // Start is called before the first frame updatev
    {
        healthBar.value = health; //healthbar value is = to the health
        damagetimer = 0; //damagertimer is set to 0
        countDown = coolDown; // rangeTimer variable = coolDown variable 
        hasShot = false; //bool 'hasShot' is set to false
    }

    
    void Update() // Update is called once per frame
    {
        
        Shoot(); //calls function Shoot();

        if(health <= 0) //if health is less than 0
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //the scene restarts
        }
    }

    void Movement() //creates function "Movement()"
    {
        Rigidbody rb = GetComponent<Rigidbody>(); //creates rigidbody variable called 'rb' which gets the rigidbody component from the gameobject the script is attatcked to

        if (Input.GetKey(KeyCode.W)) //if key "w" is pressed
        {
            rb.velocity = transform.forward * speed;
            
        }
        if (Input.GetKey(KeyCode.S)) //if key"S" is pressed
        {
            rb.velocity = transform.forward * -speed;
        }
        if (Input.GetKey(KeyCode.D)) //if key"D" is pressed
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A)) //if key"A" is pressed
        {
            rb.velocity = transform.right * -speed;
        }


        if (Input.GetKey(KeyCode.J)) //if Key "J" is pressed
        {
            transform.Rotate(Vector3.up * speedr * Time.deltaTime); //rotate clockwise
        }
        if (Input.GetKey(KeyCode.G)) //if Key "G" is pressed
        {
            transform.Rotate(-Vector3.up * speedr * Time.deltaTime); //rotate counter clockwise
        }
    }

    void Shoot() //creates function  Shoot()
    {
        countDown -= Time.deltaTime; //couuntdown
        if (countDown <= -1) //if countdown is less than or equal to -1
        {
            countDown = -1; //countdown = -1
        }

        if (Input.GetKeyDown(KeyCode.H) && hasShot == false) //if key 'H' is pressed and hasShot = false
        {

            hasShot = true; //hasShot bool is set to true

            GameObject projectile = Instantiate(Resources.Load("Box"), transform.position + transform.forward *1 , transform.rotation) as GameObject; //Player 1 istantiates a box infront of it
            place.Play(); //sound "place" is played

            if (countDown < 0) //if countdown is less than 0
            {
                countDown = coolDown;//coolDown reloads back to rangeTimer
            }
        }

        if (countDown < 0) //if countdown is less than 0
        {
            hasShot = false; // hasShot is set to false
        }
    }

    private void OnTriggerEnter(Collider other) //function that knows when object's collider is colliding with something
    {
        if(other.tag == "DeathBox") //if player 1 collides with "Deathbox"
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //the scene restarts

        }

        if (other.tag == "FallBox") // if player 1 collides with "fallBox"
        {
            fall.Play(); //fall sound plays
        }


        if (other.tag == "ElectricWall") // if player 1 collides with "ElectricWall"
        {
            electricity.Play(); //electricity sound plays
        }

        if (other.tag == "ElectricBall") // if player 1 collides with "ElectricBall"
        {
            electricity.Play(); //electricity sound plays
        }

        if (other.tag == "Spikes") // if player 1 collides with "Spikes"
        {
            spikeSound.Play(); //spikeSound sound plays
        }

        if (other.tag == "TurretBullet") // if player 1 collides with "TurretBullet"
        {
            health -= 5; //health is reduced by 5 points
            healthBar.value = health; //healthbar value is = to the health
            gettingShot.Play(); //gettingShot sound plays
        }

        if (other.tag == "FireBall") // if player 1 collides with "FireBall"
        {
            health -= 2; //health is reduced by 2 points
            healthBar.value = health; //healthbar value is = to the health
            burning.Play(); //burning sound plays
        }



    }

    private void OnTriggerExit(Collider other) // creates OnTriggerExit function
    {
        if (other.tag == "ElectricWall") //if player exits "ElectricWall"
        {
            electricity.Pause(); // play electricity sound
        }

        if (other.tag == "ElectricBall") //if player exits "ElectricBall"
        {
            electricity.Pause(); // play electricity sound
        }

        if (other.tag == "Spikes") //if player exits "Spikes"
        {
            spikeSound.Pause(); // play spikeSound sound
        }
    }



    public void OnTriggerStay(Collider other) //creates OnTriggerStay function
    {
        if (other.tag == "Floor") //if player stays on "Floor"
        {
            Movement(); //calls function Movement()
            
        }

        if (other.tag == "ElectricWall") //if player stays on "ElectricWall"
        {
            

            if (damagetimer == 0) //if damage is equal to 0
            {
                health -= 10/120f; //every sec the player looses 10 health
                healthBar.value = health; //healthbar value is = to the health

            }
            damagetimer += Time.deltaTime; //damagetime starts going up

            if (damagetimer > 1/12) //every 12th of a sec the timer resets (so that the helath bar looks smooth while taking damage
            {
                damagetimer = 0; //damagetime is set to 0
            }
            
        }

        if (other.tag == "ElectricBall") //if player stays on "ElectricBall"
        {


            if (damagetimer == 0) //if damage is equal to 0
            {
                health -= 10 / 120f; //every sec the player looses 10 health
                healthBar.value = health; //healthbar value is = to the health

            }
            damagetimer += Time.deltaTime; //damagetime starts going up

            if (damagetimer > 1 / 12) //every 12th of a sec the timer resets (so that the helath bar looks smooth while taking damage
            {
                damagetimer = 0; //damagetime is set to 0
            }

        }

        if (other.tag == "Spikes") //if player stays on "Spikes"
        {


            if (damagetimer == 0) //if damagetimer is 0
            {
                health -= 10 / 120f; //every sec the player looses 10 health
                healthBar.value = health; //healthbar value is = to the health

            }
            damagetimer += Time.deltaTime; damagetimer += Time.deltaTime; //damagetime starts going up

            if (damagetimer > 1 / 12) //every 12th of a sec the timer resets (so that the helath bar looks smooth while taking damage
            {
                damagetimer = 0; //damagetime is set to 0
            }

        }
    }

    
}
