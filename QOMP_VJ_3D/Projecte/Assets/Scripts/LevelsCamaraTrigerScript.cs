using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsCamaraTrigerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit()
    {
        GameObject.FindGameObjectWithTag("MylevelsPlayer").GetComponent<LevelsScript>().startCamaraAnimation();
    }
}
