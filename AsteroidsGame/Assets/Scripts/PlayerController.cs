using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody2D rbody;

    public List<GameObject> lives;

    [SerializeField]
    private ParticleSystem flares;

    [SerializeField]
    private GameObject laser;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private AudioSource laserSound;


    // Start is called before the first frame update
    void Start()
    {
        rbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //input keys
        PlayerInput();
        PlayerDeath();
        
    }

    public void PlayerInput()
    {
        FireLaser();
        bool goForward = Input.GetKey(KeyCode.W);
        bool turnLeft = Input.GetKey(KeyCode.A);
        bool turnRight = Input.GetKey(KeyCode.D);
        //bool goBack = Input.GetKey(KeyCode.S);

        //add player movement
        if (goForward)
        {
            rbody.AddForce(this.transform.up * 2);
            flares.Emit(1);
        }
        else if (turnLeft)
        {
            rbody.AddTorque(200);
        }
        else if (turnRight)
        {
            rbody.AddTorque(-200);
        }
    }

    //create lasers to shoot from spawn area
    void FireLaser()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //laser sound upon fire
            laserSound.Play();
            //reference the Player object directly and taking the child of that object at position 1, In this case the laser spawn
            Transform spawnArea = gameObject.transform.GetChild(1).transform;
            GameObject laserClone = Instantiate(laser, spawnArea.position, spawnArea.rotation);

            laserClone.GetComponent<Rigidbody2D>().AddForce(this.transform.up * 1000);

            Destroy(laserClone, 2.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player collides with an asteroid lose a life
        if(collision.gameObject.tag == "Asteroid") 
        {
            //destroy one of the life objects
            Destroy(lives[0].gameObject);
            lives.Remove(lives[0]);

        }
    }

    //player death to explosion
    void PlayerDeath()
    {
        if (lives.Count == 0)
        {
            //play explosion sound on player death
            AudioSource deathSound = GameObject.Find("GameManager").GetComponent<AudioSource>();
            deathSound.Play();
            Destroy(this.gameObject);
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 1f);

        }
    }

}
