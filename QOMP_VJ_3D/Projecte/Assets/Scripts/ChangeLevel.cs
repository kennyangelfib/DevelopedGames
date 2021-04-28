using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    GameObject obj;
    Vector3 posPlayer;
    PlayerController player;
    public AudioClip finishLevelSound;
    public Boolean isGoNext = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       /* posPlayer = obj.GetComponent<PlayerController>().currentPos;
        double dst = Math.Sqrt((posPlayer.x - transform.position.x) * (posPlayer.x - transform.position.x) + (posPlayer.z - transform.position.z) * (posPlayer.z - transform.position.z));
        if(dst < 2)
        {
            AudioSource.PlayClipAtPoint(finishLevelSound, posPlayer);
            //Destroy(obj);
            Invoke("changeLevel", 1);
        }*/

    }
    private void OnTriggerEnter()
    {
        Invoke("changeLvl", 0.5f);
    }


    private void changeLvl()
    { 
        int lo = GameObject.Find("GameState").GetComponent<ScriptGameState>().level;
        Debug.Log("Go next:" + isGoNext + " nivel actual: " + lo  );


        if (isGoNext && lo + 1 <= 5) GameObject.Find("GameState").GetComponent<ScriptGameState>().change_level(lo + 1);
        else if (isGoNext && lo == 5) GameObject.Find("GameState").GetComponent<ScriptGameState>().FinalGame();
        else if (!isGoNext && lo - 1 >= 1) GameObject.Find("GameState").GetComponent<ScriptGameState>().change_level(lo - 1);
        else Debug.LogError("se esta intentando cambiar a un nivel que no existe");
    }
}
