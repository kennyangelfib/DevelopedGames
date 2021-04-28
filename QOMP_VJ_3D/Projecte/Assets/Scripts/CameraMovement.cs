using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject obj;
    Vector3 posPlayer;
    public int quadAct;
    bool bottomToTop, topToBottom;
    bool test, extraControl;
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("MyPlayer");
        posPlayer = obj.GetComponent<PlayerController>().currentPos;
        bottomToTop = topToBottom = false;
        quadAct = 2;
        extraControl = false;
        //quadAct = 7;
        //transform.position = new Vector3(78-17-17-17f, 18.321f, -21.5f);
        //quadAct = 10;
        //transform.position = new Vector3(78, 18.321f, -21.5f);
        //quadAct = 12;
        //transform.position = new Vector3(27f, 18.321f, -35.5f);
        //quadAct = 14;
        //transform.position = new Vector3(61f, 18.321f, -35.5f);
    }


    public void setCamera( int quad, Vector3 posCamera){
        quadAct = quad;
        transform.position = posCamera;
    }



    // Update is called once per frame
    void Update()
    {
        posPlayer = obj.GetComponent<PlayerController>().currentPos;

        if (quadAct == 1){
            if (posPlayer.x > 19){
                quadAct = 2; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if(posPlayer.z < -15){
                topToBottom = true;
                quadAct = 6; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z-14), 1f));
            }
        }
        else if (quadAct == 6){
            if (posPlayer.z > -15){
                quadAct = 1; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 19){
                quadAct = 7; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -29){
                quadAct = 11; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 2){
            if (posPlayer.x < 19){
                quadAct = 1; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if(posPlayer.x > 36){
                quadAct = 3; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -15){
                topToBottom = true;
                quadAct = 7; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z-14), 1f));
            }
        }
        else if (quadAct == 3){
            if (posPlayer.x < 36){
                quadAct = 2; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.x > 53){
                quadAct = 4; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -15){
                topToBottom = true;
                quadAct = 8; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 7) {
            if (posPlayer.x < 19) {
                quadAct = 6; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -15){
                quadAct = 2; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+14), 1f));
            }
            else if (posPlayer.x > 36) {
                quadAct = 8; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -29){
                quadAct = 12; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 8) {
            if (posPlayer.x < 36){
                quadAct = 7; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -15){
                quadAct = 3; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }

            else if (posPlayer.x > 53){
                quadAct = 9; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -29){
                quadAct = 13; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 12){
            if (posPlayer.x < 19){
                quadAct = 11; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -29){
                bottomToTop = true;
                quadAct = 7; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 36){
                quadAct = 13; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -43){
                quadAct = 17; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 13){
            if (posPlayer.x < 36){
                quadAct = 12; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -29){
                quadAct = 8; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 53){
                quadAct = 14; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -43){
                quadAct = 18; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 18){
            if (posPlayer.x < 36){
                quadAct = 17; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -43){
                //bottomToTop = true;
                quadAct = 13; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 53){
                quadAct = 19; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
        }
        else if (quadAct == 19){
            if (posPlayer.x < 53){
                quadAct = 18; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -43){
                quadAct = 14; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 70){
                quadAct = 20; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
        }
        else if (quadAct == 14){
            if (posPlayer.x < 53){
                quadAct = 13; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -29){
                quadAct = 9; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 70){
                quadAct = 15; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -43){
                quadAct = 19; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 9){
            if (posPlayer.x < 53){
                quadAct = 8; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -15){
                quadAct = 4; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 70){
                quadAct = 10; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -29){
                quadAct = 14; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 10){
            if (posPlayer.x < 70){
                quadAct = 9; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -15){
                quadAct = 5; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.z < -29){
                //if (GameObject.Find("GameState").GetComponent<ScriptGameState>().level == 1)
                //{
                //    GameObject.Find("GameState").GetComponent<ScriptGameState>().level = 2;
                //}
                quadAct = 15; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 15){
            if (posPlayer.x < 70){
                quadAct = 14; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -29){
                if(GameObject.Find("GameState").GetComponent<ScriptGameState>().level == 1) extraControl = true;
                else if (extraControl)
                {
                    quadAct = 10; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
                }
                //if (GameObject.Find("GameState").GetComponent<ScriptGameState>().level != 1)
                //{
                //    extraControl = true;
                //    quadAct = 10; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
                //}
                //Debug.Log(GameObject.Find("GameState").GetComponent<ScriptGameState>().level);
            }
            else if (posPlayer.z < -43){
                quadAct = 20; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 4){
            if (posPlayer.x < 53){
                quadAct = 3; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.x > 70){
                quadAct = 5; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -15){
                topToBottom = true;
                quadAct = 9; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 5){
            if (posPlayer.x < 70){
                quadAct = 4; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -15){
                topToBottom = true;
                quadAct = 10; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 11){
            if (posPlayer.z > -29){
                quadAct = 6; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 19){
                quadAct = 12; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z < -43){
                quadAct = 16; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 14), 1f));
            }
        }
        else if (quadAct == 16){
            if (posPlayer.z > -43){
                quadAct = 11; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 19){
                quadAct = 17; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
        }
        else if (quadAct == 17){
            if (posPlayer.x < 19){
                quadAct = 16; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -43){
                quadAct = 12; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }
            else if (posPlayer.x > 36){
                quadAct = 18; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x + 17, transform.position.y, transform.position.z), 1f));
            }
        }
        else if (quadAct == 20){
            if (posPlayer.x < 70){
                quadAct = 19; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x - 17, transform.position.y, transform.position.z), 1f));
            }
            else if (posPlayer.z > -43){
                quadAct = 15; StartCoroutine(MoveSlowly(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 14), 1f));
            }

        }


    }


    IEnumerator MoveSlowly(Vector3 origin, Vector3 destination, float duration){
        duration = duration - 0.75f;

        //compruebo que los valores de camara en z que no salgan de sus valores correspondientes
        if (destination.z >= -7.5) destination.z = -7.5f;
        else if (destination.z >= -21.5) destination.z = -21.5f;
        else if (destination.z >= -35.5)
        {
            if (topToBottom) destination.z = -21.5f;
            else destination.z = -35.5f;
        }
        else if (destination.z >= -49.5 || destination.z < 49.5)
        {
            if (bottomToTop) destination.z = -35.5f;
            else destination.z = -49.5f;
        }
        //compruebo que los valores de camara en x que no salgan de sus valores correspondientes
        if (destination.x <= 19) destination.x = 10f;
        else if (destination.x <= 36) destination.x = 27f;
        else if (destination.x <= 53)
        {
            destination.x = 44f;
        }
        else if (destination.x <= 70)
        {
            destination.x = 61f;
        }
        else if (destination.x > 70)
        {
            destination.x = 78f;
        }


        topToBottom = bottomToTop = false;
        
        for (float t = 0f; t < duration; t += Time.deltaTime){
            transform.position = Vector3.Lerp(origin, destination, t / duration);
            yield return 0;
        }    
        transform.position = destination;

        //Debug.Log("TPosition: " + transform.position);
    }

}
