using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public AudioClip sound;
    ParticleSystem [] ps;
    private bool first, active;
    public int control;

    void Start()
    {
        ps = this.GetComponentsInChildren<ParticleSystem>();
        first = active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            active = false;
            foreach (ParticleSystem p in ps)
                p.Play();
        }
    }

    private void OnTriggerEnter(Collider co)
    {
        if (first)
        {
            first = false;
            GetComponent<AudioSource>().PlayOneShot(sound);
            //only for level 2
            ScriptGameState.onlyinst.lastCheckPointPos = transform.position;
            ScriptGameState.onlyinst.lastCheckPointIs_Pos_ini_change_Level = false;
            if (control == 1)
            {
                ScriptGameState.onlyinst.quad = 4;
                ScriptGameState.onlyinst.cameraPos = new Vector3(61f, 18.321f, -7.5f);
            }
            else if(control == 2)
            {
                ScriptGameState.onlyinst.quad = 12;
                ScriptGameState.onlyinst.cameraPos = new Vector3(27f, 18.321f, -35.5f);
            }
            else if (control == 3)
            {
                ScriptGameState.onlyinst.quad = 18;
                ScriptGameState.onlyinst.cameraPos = new Vector3(44f, 18.321f, -49.5f);
            }
            else if (control == 4)
            {
                ScriptGameState.onlyinst.quad = 8;
                ScriptGameState.onlyinst.cameraPos = new Vector3(44f, 18.321f, -21.5f);
            }
            else if (control == 5)
            {
                ScriptGameState.onlyinst.quad = 10;
                ScriptGameState.onlyinst.cameraPos = new Vector3(78f, 18.321f, -21.5f);
            }
            else if (control == 6)
            {
                ScriptGameState.onlyinst.quad = 7;
                ScriptGameState.onlyinst.cameraPos = new Vector3(27f, 18.321f, -21.5f);
            }
            else if (control == 7)
            {
                ScriptGameState.onlyinst.quad = 6;
                ScriptGameState.onlyinst.cameraPos = new Vector3(10f, 18.321f, -21.5f);
            }
            else if (control == 8)
            {
                ScriptGameState.onlyinst.quad = 16;
                ScriptGameState.onlyinst.cameraPos = new Vector3(10f, 18.321f, -49.5f);
            }
            else if (control == 9)
            {
                ScriptGameState.onlyinst.quad = 20;
                ScriptGameState.onlyinst.cameraPos = new Vector3(78f, 18.321f, -49.5f);
            }
            Destroy(this.GetComponentInChildren<ParticleSystem>());
        }
    }
}
