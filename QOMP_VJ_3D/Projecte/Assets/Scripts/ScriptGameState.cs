using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script saves the general state of the game.
public class ScriptGameState : MonoBehaviour
{
    // Singleton
    public static ScriptGameState onlyinst;
    public int level, quad, last_level;
    public bool closeDotWall2;
    public Vector3 lastCheckPointPos, cameraPos;
    public bool lastCheckPointIs_Pos_ini_change_Level;//Es true Si el lastCheckpoint es la posicion de inicio cuando se cambia de nivel
    public Vector3 lastCheckPoint_change_level_player_direction;//
    public bool[] levelLock;
    public bool generalMapView;
    string currentSceneName;
    private void Awake()
    {
        // Singleton
        if (ScriptGameState.onlyinst == null)
        {
            ScriptGameState.onlyinst = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //lastCheckPointIs_Pos_ini_change_Level = true;//ha de ser verdadera por antes de esta no habia ninguncheckpoint
        //Para poder hacer pruebas con un nivel espeficico comentar estas dos lineas,
        level = 1;
        last_level = 1;
        closeDotWall2 = false;
        lastCheckPointPos = new Vector3(27f, 0.5f, -8f);
        cameraPos = new Vector3(27f, 18.321f, -7.5f);
        quad = 2;
        levelLock = new bool[] {false, true,true,true,true};
        generalMapView = false;
        //currentSceneName = Application.loadedLevelName;
        currentSceneName = "Level1  "; //"MainMenu";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKey(KeyCode.M)){
            LoadScene("MainMenu");
           // SceneManager.LoadScene("MainMenu");

            Start();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) LevelSetWithkeys(1);

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) LevelSetWithkeys(2);

        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) LevelSetWithkeys(3);
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) LevelSetWithkeys(4);
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) LevelSetWithkeys(5);
        


        if (Input.GetKeyDown(KeyCode.C)){
            Debug.Log("Cambiar camara");
            generalMapView = !generalMapView;
            if (GameObject.FindGameObjectWithTag("CamerasController") != null) //solo ha de existir en los niveles en niguna escena mas.
                GameObject.FindGameObjectWithTag("CamerasController").GetComponent<CamerasController>().DetermineCamera();
        }
      


    }
    /*
    private bool GeneralViewIsViable() {

        String[] viableScenes = { "Level1", "Level2", "Level3", "Level4", "Level5" };
        for (int i = 0; i < viableScenes.Length; i++) 
            if (viableScenes[i] == currentSceneName) return true;
        return false;
    }*/


    private void LevelSetWithkeys(int lvl)
    {
        level = last_level = lvl;
        levelLock[lvl - 1] = false;
        change_level(level);
    }

    public void restart()
    {
        Debug.Log("--- " + lastCheckPointPos + " " + quad + " " + cameraPos);
        GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<Rigidbody>().position = lastCheckPointPos; //playerPos
        if (lastCheckPointIs_Pos_ini_change_Level)
        {
            GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<PlayerController>().direction = lastCheckPoint_change_level_player_direction;
        }
        //Hacemos que pare el player y luego de 0.5 segundo lo activamos.
        GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<PlayerController>().Stop();
        Invoke("aux_restart", 1);
        GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<PlayerController>().currentPos = lastCheckPointPos;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().setCamera(quad, cameraPos);
    }
    private void aux_restart() {
        GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<PlayerController>().Continue();
    }

    /*public void change_level(int origin, int destino ) { 
    }*/

    public void change_level(int destine)
    {
        //Debug.Log("lo" + last_level + "ld" + level);
        last_level = this.level;
        level = destine;
        LoadScene("Levels");
        //SceneManager.LoadScene("Levels");
    }

    public void KeyCollected()
    {
        // desbloqueamos el siguiente nivel, level nos indica el nivel actual,pero su 
        //posicion en el array levelLock  es level-1, por lo cual la posicion corerspondiente al siguinte nivel es el valor de level
        levelLock[level] = false;
        Destroy(GameObject.FindGameObjectWithTag("Key"));
    }
    public bool is_level_locked()
    {
        return levelLock[level-1];
    }
    public bool is_next_level_locked() {
        if (level == 5) return true;
        else return levelLock[level];
    }
    public void FinalGame()
    {
        LoadScene("TheEnd");
        this.Start();//volvemos a poner los valores por defecto de inicio
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        currentSceneName = name;

        //determineCamera();
      
    }
    /*void determineCamera()
    {
        /// if (GameObject.FindGameObjectWithTag("MyPlayer") != null) {
        //     Debug.Log("Existe La instancia de player");
        // }
        if (GameObject.FindGameObjectWithTag("CameraController") != null)
        {
            Debug.Log("Existe main camera");
        }

        if (GameObject.FindGameObjectWithTag("MainCamera") != null) {
            Debug.Log("Existe main camera");
        }
        if (GameObject.FindGameObjectWithTag("GeneralCamaraView") != null)
        {
            Debug.Log("Existe General camera");
        }

        if (generalMapView && GeneralViewIsViable())
        {
            GameObject.FindGameObjectWithTag("GeneralCamaraView").SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
            
        }
        else
        {
            if (GameObject.Find("MainCamera") != null) Debug.Log("Existe La instancia ");

            //.SetActive(true);
            if (GameObject.FindGameObjectWithTag("GeneralCamaraView") != null)
            {
                GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
            }
        }
    }*/
}
