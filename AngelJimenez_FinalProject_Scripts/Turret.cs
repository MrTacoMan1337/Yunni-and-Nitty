using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public GameObject playerLook;
    public float rangeTimer; //creates float variable 'rangeTimer'
    public float coolDown; //creates float variable 'coolDown   
    public float aggroRange; //creates public float variable 'aggroRange'
    public int speed;
    private Transform player; //creates private transform variable 'player'
    public Slider timeBar; //creates public slider variable 'healthBr'
    public GameObject shootingPoint;
    public AudioSource shootAudio;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player1").transform; //marks tagged object 'Player'as 'player' variable
        rangeTimer = coolDown; // rangeTimer variable = coolDown variable 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, playerLook.transform.position) < aggroRange) //if player distance is less that 'aggroRange' and health is more than 0
        {
            transform.LookAt(playerLook.transform.position); //enemy looks at player
            rangeTimer -= Time.deltaTime; //couuntdown 
            timeBar.value = rangeTimer;
            
            if (rangeTimer <= 0)// when countDown reaches0 sec
            {
                rangeTimer = coolDown;//coolDown reloads back to rangeTimer
                shootAudio.Play();
                GameObject projectile = Instantiate(Resources.Load("CannonBullet"), shootingPoint.transform.position, transform.rotation) as GameObject; //enemy launches projectile 'ball' from resources folder
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed * 10); //projectile has a forward froce of 50
            }
        }
    }
}
