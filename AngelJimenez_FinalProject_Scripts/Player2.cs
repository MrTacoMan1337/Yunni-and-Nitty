using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public float speed = 7f; //creates public float "speed" and sets it to 7f
    public float speedr = 100; //creates public float "speedr" and sets it to 100

    public int bulletForce = 200; //creates public int "bulletForce" and is set to 200
    public bool hasShot; //creates public bool "hasShot"

    public float countDown; //creates float variable 'countDown'
    public float coolDown = 2; //creates float variable 'coolDown 

    public AudioSource shootSound; //creates public AudioSource "place"
    public AudioSource fall; //creates public AudioSource "fall"
    public AudioSource electricity; //creates public AudioSource "electricity"
    public AudioSource gettingShot; //creates public AudioSource "gettingShot"
    public AudioSource burning; //creates public AudioSource "burning"
    public AudioSource spikeSound; //creates public AudioSource "spikeSound"

    public float health = 100f; //create public float called health and set it to 100f
    public Slider healthBar; //create Slider names healthBar
    public float timer; //creates public float named "timer"

    public GameObject portal1; //creates public GameObject called portal1
    public GameObject portal2; //creates public GameObject called portal2
    private bool inPortal1; //creates private bool called inPortal1
    private bool inPortal2; //creates private bool called inPortal2

    void Start() // Start is called before the first frame update
    {
        healthBar.value = health; //healthbar value is = to the health
        timer = 0; //damagertimer is set to 0
        countDown = coolDown; // rangeTimer variable = coolDown variable 
        hasShot = false; //bool 'hasShot' is set to false
        /*inPortal1 = true; //sets inPortal1 to true
        inPortal2 = true; //sets inPortal2 to true*/
    }

   
    void Update()  // Update is called once per frame
    {
        Shoot(); //calls function Shoot();

        if (health <= 0) //if health is less than 0
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //the scene restarts
        }
    }

    void Movement() //creates function "Movement()"
    {
        //Vector3 pos = transform.position; //creates Vector3 variable "pos" and is set to the position of the gameobject "player2"
        Rigidbody rb = GetComponent<Rigidbody>(); //creates rigidbody variable called 'rb' which gets the rigidbody component from the gameobject the script is attatcked to

        if (Input.GetKey(KeyCode.UpArrow)) //if key "UpArrow" is pressed
        {
            //pos.z += speed * Time.deltaTime; //player goes fowward
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow)) //if key "DownArrow" is pressed
        {
            //pos.z -= speed * Time.deltaTime; //player goes backwards
            rb.velocity = transform.forward * -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow)) //if key "RightArrow" is pressed
        {
            //pos.x += speed * Time.deltaTime; //player goes to the right
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //if key "LeftArrow" is pressed
        {
            //pos.x -= speed * Time.deltaTime; //player goes to the left
            rb.velocity = transform.right * -speed;
        }
        //transform.position = pos; //player position is set to "pos"


        if (Input.GetKey(KeyCode.Keypad1)) //if key "Keupad1" is pressed
        {
            transform.Rotate(-Vector3.up * speedr * Time.deltaTime);//rotate clockwise
        }
        if (Input.GetKey(KeyCode.Keypad3))//if key "Keypad3" is pressed
        {
            transform.Rotate(Vector3.up * speedr * Time.deltaTime); //rotate counter clockwise
        }

    }

    void Shoot() //creates function  Shoot()
    {
        countDown -= Time.deltaTime; //couuntdown
        if(countDown <= -1) //if countdown is less than or equal to -1
        {
            countDown = -1; //countdown = -1
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && hasShot == false) //if key 'Keypad2' is pressed and hasShot = false
        {

            hasShot = true; //hasShot bool is set to true

            GameObject projectile = Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation) as GameObject; //Player 2 istantiates a box infront of it
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce); //projectile goes forward with a force of "bulletForce"
            shootSound.Play(); //sound "shootSound" is played

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
        if (other.tag == "DeathBox") //if player 2 collides with "Deathbox"
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //the scene restarts

        }

        if (other.tag == "FallBox") // if player 2 collides with "fallBox"
        {
            fall.Play(); //fall sound plays
        }

        if (other.tag == "ElectricWall") // if player 2 collides with "ElectricWall"
        {
            electricity.Play(); //electricity sound plays
        }

        if (other.tag == "ElectricBall") // if player 2 collides with "ElectricBall"
        {
            electricity.Play(); //electricity sound plays
        }

        if (other.tag == "Spikes") // if player 2 collides with "Spikes"
        {
            spikeSound.Play(); //spikeSound sound plays
        }

        if (other.tag == "TurretBullet") // if player 2 collides with "TurretBullet"
        {
            health -= 5; //health is reduced by 5 points
            healthBar.value = health; //healthbar value is = to the health
            gettingShot.Play(); //gettingShot sound plays
        }

        if (other.tag == "FireBall") // if player 2 collides with "FireBall"
        {
            health -= 2; //health is reduced by 2 points
            healthBar.value = health; //healthbar value is = to the health
            burning.Play(); //burning sound plays
        }

        /*if (other.tag == "Portal1" && inPortal1 == true)
        {
            inPortal2 = false;
            transform.position = portal2.transform.position;
        }

        if (other.tag == "Portal2" && inPortal2 == true)
        {
            inPortal1 = false;
            transform.position = portal1.transform.position;
        }*/
    }

    public void OnTriggerExit(Collider other) // creates OnTriggerExit function
    {
        /*if (other.tag == "Portal1")
        {
            inPortal1 = true;
        }
        if (other.tag == "Portal2")
        {
            inPortal2 = true;
        }*/

        if (other.tag == "ElectricWall") //if player exits "ElectricBall"
        {
            electricity.Pause(); // play electricity sound
        }

        if (other.tag == "ElectricBall") //if player exits "ElectricWall"
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


            if (timer == 0) //if damage is equal to 0
            {
                health -= 10 / 120f; //every sec the player looses 10 health
                healthBar.value = health; //healthbar value is = to the health
            }
            timer += Time.deltaTime; // timer starts going up

            if (timer > 1 / 12) //every 12th of a sec the timer resets (so that the helath bar looks smooth while taking damage
            {
                timer = 0; //time is set to 0
            }

        }

        if (other.tag == "ElectricBall") //if player stays on "ElectricBall"
        {


            if (timer == 0) //if damage is equal to 0
            {
                health -= 10 / 120f; //every sec the player looses 10 health
                healthBar.value = health; //healthbar value is = to the health

            }
            timer += Time.deltaTime; //damagetime starts going up

            if (timer > 1 / 12) //every 12th of a sec the timer resets (so that the helath bar looks smooth while taking damage
            {
                timer = 0; //damagetime is set to 0
            }

        }

        if (other.tag == "Spikes") //if player stays on "Spikes"
        {


            if (timer == 0)
            {
                health -= 10 / 120f; //every sec the player looses 10 health
                healthBar.value = health; //healthbar value is = to the health
            }
            timer += Time.deltaTime; //timer starts going up

            if (timer > 1 / 12) //every 12th of a sec the timer resets (so that the helath bar looks smooth while taking damage
            {
                timer = 0; //damagetime is set to 0
            }

        }
    }
}
