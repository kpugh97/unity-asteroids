using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to determine which game object is being collided with and determine the behavior
public class CollisionBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

     void OnCollisionEnter2D(Collision2D collision)
    {
        //create a new textbehavior object and update the text component in the game manager
        TextBehavior updateScore = GameObject.Find("GameManager").GetComponent<TextBehavior>();
        AudioSource explosionSound = GameObject.Find("GameManager").GetComponent<AudioSource>();

        //check to see if a laser and barrier have collided
        if (this.gameObject.tag == "Laser" && collision.gameObject.tag == "Barrier")
        {
            //destroy the laser
            Destroy(gameObject);
        }

        //check to see if a laser and asteroid have collider with one another
        if (this.gameObject.tag == "Laser" && collision.gameObject.tag == "Asteroid")
        {
            //destroy the laser
            Destroy(gameObject);
           
        }

        if(this.gameObject.tag == "Asteroid" && collision.gameObject.tag == "Laser")
        {
            //update the score by 1 point 
            updateScore.scoreNum += 1;
            //play blow up sound
            explosionSound.Play();
            //destroy the asteroid
            Destroy(gameObject);
            //after collision create an explosion and destory it
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 1f);
        }
    }
}
