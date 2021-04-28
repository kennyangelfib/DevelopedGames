﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInZ : MonoBehaviour
{
    public Vector3 direction;
    float speed, previousTime;
    private bool godMode;
    void Start()
    {
        speed = 9;
        GetComponent<Rigidbody>().velocity = speed * direction;
        godMode = false;
    }


    void Update()
    {
        previousTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.P) && previousTime > 1.0f)
        {
            previousTime = 0.0f;
            godMode = !godMode;
        }
        if (godMode) GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        else GetComponent<Rigidbody>().velocity = speed * direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Floor"))
            direction.z *= -1;
        if (collision.gameObject.name.Equals("Player"))
        {
            if (!godMode) ScriptGameState.onlyinst.restart();
        }
    }
}
