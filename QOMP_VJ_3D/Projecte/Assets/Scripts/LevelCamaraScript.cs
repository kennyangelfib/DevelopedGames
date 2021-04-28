using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCamaraScript : MonoBehaviour
{
    public void ToTarget(Vector3 target) {
        Vector3 heading = target - this.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        float speed = 20;
        GetComponent<Rigidbody>().velocity = speed * direction;
    }

    public void OnTriggerEnter()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0;
        GameObject.FindGameObjectWithTag("MylevelsPlayer").GetComponent<LevelsScript>().LoadSceneOfNextLevel();
    }
}
