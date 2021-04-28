using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int lo, ld;
    public Vector3 direction;
    /*private float chickPerSecond = 3.0f;*/
    private float speed, previousTime;
    public Vector3 currentPos;
    public ParticleSystem playerParticle, speedParticle;
    public AudioClip touchSound, shootSound;
    public bool arrived;

    private Vector3[] l_pos = { new Vector3(3.5f,0.5f,-15.5f), new Vector3(19.5f, 0.5f, -15.5f),
            new Vector3(19.5f, 0.5f, -26.5f), new Vector3(35.5f, 0.5f, -26.5f),new Vector3(35.5f, 0.5f, -4.5f)};

    void Start()
    {
        lo  = GameObject.Find("GameState").GetComponent<ScriptGameState>().last_level;
        ld = GameObject.Find("GameState").GetComponent<ScriptGameState>().level;
        if (lo == ld) {
            currentPos = this.transform.position = l_pos[lo - 1];
            GetComponent<Rigidbody>().position = currentPos;
            this.direction = new Vector3(0, 0, 0);
            speed = 0f;
            GetComponent<Rigidbody>().velocity = speed * direction;
            arrived = true;
            Invoke("startCamaraAnimation", 0.5f);
        }
        else { 
            //Debug.Log("La posion inicial es " + l_pos[lo - 1]);
            float x, z;
            //Las siguientes linesas son para calucular la direccion.
            if (l_pos[lo - 1].x == l_pos[ld - 1].x) x = 0f;
            else if (l_pos[lo - 1].x < l_pos[ld - 1].x) x = 1f;
            else x = -1f;
            if (l_pos[lo - 1].z == l_pos[ld - 1].z) z = 0f;
            else if (l_pos[lo - 1].z < l_pos[ld - 1].z) z = 1f;// esto es asi por que trabajamos en el cuadrante donde z es negativo.
            else z = -1f;
            this.direction = new Vector3(x, 0f, z);
            this.speed = 8f;
            currentPos = this.transform.position = l_pos[lo - 1];
            //Debug.Log("La direccion es " + direction);
            GetComponent<Rigidbody>().velocity = speed * direction;
            //playerParticle = GetComponent<ParticleSystem>();
            playerParticle.Stop();
            speedParticle.Stop();
            arrived = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("he colisionado con:" + collision.collider.gameObject.name);
        GetComponent<Rigidbody>().velocity = 0 * direction;
        arrived = true;
        //Debug.Log("llege");
    }
    public void startCamaraAnimation() {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelCamaraScript>().ToTarget(l_pos[ld - 1]); 
    }
    public void LoadSceneOfNextLevel() {

        GameObject.Find("GameState").GetComponent<ScriptGameState>().LoadScene("Level" + ld);
    }
}
