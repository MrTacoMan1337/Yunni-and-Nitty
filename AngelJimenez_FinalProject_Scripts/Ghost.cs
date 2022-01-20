using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{

    public float rangeTimer; //creates float variable 'rangeTimer'
    public float coolDown; //creates float variable 'coolDown   
    public float aggroRange; //creates public float variable 'aggroRange'
    public int speed;
    private Transform player; //creates private transform variable 'player'
   
    public GameObject shootingPoint;
    //public AudioSource uhh; //creates public Audiosource variable 'uhh'

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1").transform; //marks tagged object 'Player'as 'player' variable
        rangeTimer = coolDown; // rangeTimer variable = coolDown variable 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position); //enemy looks at player
        if (Vector3.Distance(transform.position, player.position) < aggroRange) //if player distance is less that 'aggroRange' and health is more than 0
        {
            rangeTimer -= Time.deltaTime; //couuntdown 

            if (rangeTimer <= 0)// when countDown reaches0 sec
            {
                rangeTimer = coolDown;//coolDown reloads back to rangeTimer

                GameObject projectile = Instantiate(Resources.Load("GhostBall"), shootingPoint.transform.position, transform.rotation) as GameObject; //enemy launches projectile 'ball' from resources folder
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed * 10); //projectile has a forward froce of 50
            }
        }
    }
}
