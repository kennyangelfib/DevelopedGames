using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private int current_auxiliar_camera;
    public Camera mainCamera, generalViewCamera;
    public Camera camera_1, camera_2, camera_3, camera_4, camera_5, camera_6;
    private Camera[] list_cameras;
    void initializePrincipalCameras() {
        mainCamera.enabled = true;
        generalViewCamera.enabled = false;
    }

    void initializeAuxiliarCameras()
    {
        list_cameras = new Camera[6] { camera_1, camera_2, camera_3, camera_4, camera_5, camera_6 };
        for (int i = 0; i < list_cameras.Length; i++)
            list_cameras[i].enabled = false;
        current_auxiliar_camera = 0;
    }

    void setCamera(char principal_camera, int number, bool is_auxiliar_camera)
    {
        if (is_auxiliar_camera)
        {
            if (current_auxiliar_camera != number)
            {
                list_cameras[number - 1].enabled = true;
                if (current_auxiliar_camera != 0)
                {
                    list_cameras[current_auxiliar_camera - 1].enabled = false;
                }
                else {
                    generalViewCamera.enabled = false;
                    mainCamera.enabled = false;
                }
                current_auxiliar_camera = number;
                
            }
        }
        else {
            if (principal_camera == 'g') {
                generalViewCamera.enabled = true;
                mainCamera.enabled = false;
            }
            if (principal_camera == 'm') {
                mainCamera.enabled = true;
                generalViewCamera.enabled = false;
            }
            if (current_auxiliar_camera != 0)
            {
                list_cameras[current_auxiliar_camera - 1].enabled = false;
                current_auxiliar_camera = 0;
            }
        }
    }
    void evaluateCameras()
    {

        if (Input.GetKeyDown(KeyCode.G)) setCamera('g', 0, false);

        if (Input.GetKeyDown(KeyCode.M)) setCamera('m', 0, false);

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) setCamera('_',1,true);

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) setCamera('_', 2, true);

        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) setCamera('_', 3, true);

        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) setCamera('_', 4, true);

        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) setCamera('_', 5, true);

        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6)) setCamera('_', 6, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        initializePrincipalCameras();
        initializeAuxiliarCameras();
    }


    // Update is called once per frame
    void Update()
    {
        evaluateCameras();
    }
}
