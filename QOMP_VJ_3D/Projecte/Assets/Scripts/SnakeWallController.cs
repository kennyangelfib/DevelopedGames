using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWallController : MonoBehaviour
{
    public ParticleSystem snackWallParticle;
    public AudioClip explosionSound;


    void Start()
    {
        snackWallParticle.Stop();
    }


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeMovement>().openWall)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            //this.gameObject.SetActive(false);
        }
        else GetComponent<BoxCollider>().isTrigger = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Snake") != null) 
        {
            AudioSource.PlayClipAtPoint(explosionSound, new Vector3(61f, 0.5f, -35.5f));
            GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeMovement>().destroySnake();
            Destroy(GameObject.Find("SnakePointModel"));
            Destroy(GameObject.Find("SnakePoint"));
            snackWallParticle.Play();
            GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeMovement>().openWall = true;
            Destroy(this.gameObject);
        }
        
    }
}
