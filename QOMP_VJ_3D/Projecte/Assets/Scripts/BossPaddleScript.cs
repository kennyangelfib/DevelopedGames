using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossPaddleScript : MonoBehaviour
{
    private float speed, previousTime;
    private Rigidbody rb;
    GameObject obj;
    PlayerController playerScript;
    private bool godMode, up;
    public bool moveAlways, special1, special2;
    public bool isEscapist;
    //public GameObject livesWall;
    public TextMeshPro TextWallLives;
    private int lives;
    Vector3 move = Vector3.zero;
    bool firstCollisionWithPlayer;
    public GameObject[] quadPeaks = new GameObject[3];
    int numOfPickToactivate;
    public GameObject lastwall;
    public GameObject TriggerOfFirstWall;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obj = GameObject.FindGameObjectWithTag("MyPlayer");
        playerScript = obj.GetComponent<PlayerController>();
        godMode = up = false;
        firstCollisionWithPlayer = true;
        TextWallLives.text = "";
        isEscapist = true;
        speed = 0;
        disableAllPeaks();
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
                    else
                    {
                        if (special2 && playerScript.currentPos.z > -44) rb.velocity = new Vector3(0, 0, 0);
                        else rb.velocity = new Vector3(0, 0, speed);
                    }
                }
                else if (dif < 0)
                {
                    if (isEscapist) rb.velocity = new Vector3(0, 0, speed);
                    else
                    {
                        if (special1 && playerScript.currentPos.z < -40) rb.velocity = new Vector3(0, 0, 0);
                        else rb.velocity = new Vector3(0, 0, -speed);
                    }
                }
                else rb.velocity = new Vector3(0, 0, 0);
            }
            else if (moveAlways)
            {
                if (up) rb.velocity = new Vector3(0, 0, speed);
                else rb.velocity = new Vector3(0, 0, -speed);
            }
            else rb.velocity = new Vector3(0, 0, 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        up = !up;

        if (isEscapist && collision.collider.gameObject.CompareTag("MyPlayer"))
        {
            if (firstCollisionWithPlayer)
            {
                firstCollisionWithPlayer = false;
                Invoke("StartBossGame", 1);
            }
            else decreaselive();
        }
    }
    public void RestartBossGame()
    {
        this.Start();
        TriggerOfFirstWall.GetComponent<SpecialWallTrigger>().ChangeStates();

    }
    private void StartBossGame()
    {
        moveAlways = true;
        speed = 8f;
        lives = 5;
        decreaselive();//la primera vez que me tocan
    }

    private void writeLives()
    {
        if (TextWallLives != null)
        {
            String text_lives = "";
            switch (lives)
            {
                case 1: text_lives = "♥"; break;
                case 2: text_lives = "♥\n♥"; break;
                case 3: text_lives = "♥\n♥\n♥"; break;
                case 4: text_lives = "♥\n♥\n♥\n♥"; break;
            }
            TextWallLives.text = text_lives;
        }
    }
    public void decreaselive()
    {
        activateNeededPeak();
        //Invoke("activateNeededPeak", 0.5);

        if (lives - 1 >= 0)
        {
            lives--;
            writeLives();
        }
        if (lives == 0)
        {
            FinishBossGame();
        }
    }

    private void FinishBossGame()
    {
        Debug.Log("Desaparece");
        isEscapist = false;
        disableAllPeaks();
        lastwall.SetActive(false);
    }

    private void activateNeededPeak()
    {
        if (5 - lives <= 2) quadPeaks[5 - lives].SetActive(true);
    }
    private void disableAllPeaks()
    {
        for (int i = 0; i < quadPeaks.Length; i++) quadPeaks[i].SetActive(false);
    }

}
