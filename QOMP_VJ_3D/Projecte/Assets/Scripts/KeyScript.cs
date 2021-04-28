using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("GameState").GetComponent<ScriptGameState>().is_next_level_locked()) Destroy(this.gameObject);
    }
}
