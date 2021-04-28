using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeMovement : MonoBehaviour
{
    private Vector3 posPlayer;
    private bool start;
    public GameObject bodyPartPrefab;
    PlayerController player;
    public bool openWall;
    List<GameObject> prefabsSnakeBody = new List<GameObject>();
    int index;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<PlayerController>();
        start = openWall = false;
        //first = true;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        posPlayer = player.currentPos;
        
        double dst = Math.Sqrt((posPlayer.x - transform.position.x) * (posPlayer.x - transform.position.x) + (posPlayer.z - transform.position.z) * (posPlayer.z - transform.position.z));
        if (dst < 2 && !start)
        {
            start = openWall = true;
            GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<Rigidbody>().position = transform.position;
        }

        if (start)
        {
            posPlayer = GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<Rigidbody>().position;
            GameObject obj = Instantiate(bodyPartPrefab);
            obj.transform.position = new Vector3(posPlayer.x, posPlayer.y, posPlayer.z);
            prefabsSnakeBody.Add(obj);
            if(index >= 30) prefabsSnakeBody[index-30].GetComponent<BoxCollider>().isTrigger = false;
            ++index;

        }

    }



    public void destroySnake()
    {
        GameObject[] objSnakeBody = GameObject.FindGameObjectsWithTag("SnakeBody");

        foreach (GameObject obj in objSnakeBody){
            Destroy(obj);
        }

        start = openWall = false;
        index = 0;
        prefabsSnakeBody = new List<GameObject>();

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!first){
        //    Debug.Log("SnakeMovement-Trigger-Eliminar");
        //    destroySnake();
        //    //first = true;
        //}
        //else first = false;

    }






}
