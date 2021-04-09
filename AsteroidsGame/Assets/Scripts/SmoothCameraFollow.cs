using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour

{
    //follow player slowly

    private Transform playerTrans;
    private float smoothTime = 2.5f;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the camera to follow player
        Vector3 targetPosition = new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z);

        //add smoothdamp to camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); ;
    }
}
