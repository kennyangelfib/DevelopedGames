using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public Camera mainCamera, generalViewCamera;

    // Start is called before the first frame update
    void Start()
    {
        DetermineCamera();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DetermineCamera()
    {
        if (GameObject.Find("GameState").GetComponent<ScriptGameState>().generalMapView)
        {
            if (generalViewCamera != null)
            {
                generalViewCamera.enabled = true;
                mainCamera.enabled = false;
            }
        }
        else
        {
            mainCamera.enabled = true;
            if (generalViewCamera != null) generalViewCamera.enabled = false;
        }
    }
}
