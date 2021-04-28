using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaddleControllerInZ : MonoBehaviour
{
    private float speed,previousTime;
    private Rigidbody rb;
    GameObject obj;
    PlayerController playerScript;
    private bool godMode, up;
    public bool moveAlways, special1, special2;
    public bool isEscapist;
    public GameObject livesWall;
    Vector3 move = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 8f;
        obj = GameObject.FindGameObjectWithTag("MyPlayer");
        playerScript = obj.GetComponent<PlayerController>();
        godMode = up = false;
    }

    // Update is called once per frame
    void Update()
    {
        previousTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.P) && previousTime > 1.0f)
        {
            previousTime = 0.0f;
            godMode = !godMode;
        }


        if (!godMode)
        {
            double dst = Math.Sqrt((playerScript.currentPos.x - transform.position.x) * (playerScript.currentPos.x - transform.position.x) + (playerScript.currentPos.z - transform.position.z) * (playerScript.currentPos.z - transform.position.z));
            if (dst < 8)
            {
                float dif = playerScript.currentPos.z - transform.position.z;
                if (dif > 0)
                {
                    if (isEscapist) rb.velocity = new Vector3(0, 0, -speed);
                    else {
                        if (special2 && playerScript.currentPos.z > -44) rb.velocity = new Vector3(0, 0, 0);
                        else rb.velocity = new Vector3(0, 0, speed);
                    }
                }
                else if (dif < 0)
                {
                    if (isEscapist)  rb.velocity = new Vector3(0, 0, speed);
                    else {
                            if (special1 && playerScript.currentPos.z < -40) rb.velocity = new Vector3(0, 0, 0);
                            else rb.velocity = new Vector3(0, 0, -speed);
                    }
                }
                else rb.velocity = new Vector3(0, 0, 0);
            }
            else if (moveAlways)
            {
                if(up) rb.velocity = new Vector3(0, 0, speed);
                else rb.velocity = new Vector3(0, 0, -speed);
            }
            else rb.velocity = new Vector3(0, 0, 0);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        up = !up;
        if (isEscapist && collision.collider.gameObject.CompareTag("MyPlayer")){
            if (livesWall != null) livesWall.GetComponent<LivesWallScript>().decreaselive();
        }
        
    }

}

