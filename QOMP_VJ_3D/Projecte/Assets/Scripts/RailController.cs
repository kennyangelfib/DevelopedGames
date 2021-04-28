using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RailController : MonoBehaviour
{

    GameObject obj;
    PlayerController playerScript;
    public bool isVertical;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("MyPlayer");
        playerScript = obj.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnTriggerEnter(Collider col) {
        playerScript.getOnRail(isVertical, transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        playerScript.getOffRail();
    }
}
