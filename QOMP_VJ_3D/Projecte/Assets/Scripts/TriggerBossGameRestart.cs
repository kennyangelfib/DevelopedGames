using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossGameRestart : MonoBehaviour
{
    public GameObject BossPaddle; 
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("MyPlayer"))

            BossPaddle.GetComponent<BossPaddleScript>().RestartBossGame();
    }
}
