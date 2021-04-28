using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    //This loads the scene with the name that is pass in the argument
    public void LoadScene(string name) {
        GameObject.Find("GameState").GetComponent<ScriptGameState>().LoadScene(name);
    }
}
