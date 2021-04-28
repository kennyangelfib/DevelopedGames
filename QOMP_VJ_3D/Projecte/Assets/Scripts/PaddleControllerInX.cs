using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaddleControllerInX : MonoBehaviour
{
    private float speed, previousTime;
    private Rigidbody rb;
    GameObject obj;
    PlayerController playerScript;
    private bool godMode;
  

    Vector3 move = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 9f;
        obj = GameObject.FindGameObjectWithTag("MyPlayer");
        playerScript = obj.GetComponent<PlayerController>();
        godMode = false;
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
                float dif = playerScript.currentPos.x - transform.position.x;
                if (dif > 0)
                {
                    rb.velocity = new Vector3(speed, 0, 0);
                }
                else if (dif < 0)
                {
                    rb.velocity = new Vector3(-speed, 0, 0);
                }
                else
                {
                    rb.velocity = new Vector3(0, 0, 0);
                }
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        //else Debug.Log("GodMode-paddle");


    }
}

