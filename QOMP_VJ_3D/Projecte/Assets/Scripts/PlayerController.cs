using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Vector3 direction;
    private float chickPerSecond = 3.0f;
    private float speed, previousTime;
    public Vector3 currentPos;
    public ParticleSystem playerParticle, speedParticle;
    public AudioClip touchSound, shootSound;
    public bool firstTimeRail, godMode;
    public bool onRail;
    public bool railVertical;
    private bool deleteSnake;
    //Atencion!!!falta completar las posiones para los niveles 4 y 5;recuerda que el array el level 1 esta en la posicion 0
    //Una vez se haya actualizado, para evitar errores, se ha de comentar los dos arryas y tambien sus llammadas, luego abrir unity y abrir cada uno de los niveles luego, decomentar y abriri en cada nivel y dar play y luego stop,
    // despues descomentar los vectores y las lineas en las que se usan, con esto ya deberia ir bien.
    public Vector3[] player_pos_ini_next = { new Vector3(27f, 0.5f, -8.0f), new Vector3(4.5f, 0.5f, -6.5f), new Vector3(9.5f, 0.5f, -4.5f), new Vector3(4.5f, 0.5f, -8f), new Vector3(1f, 0f, 1f) };
    public Vector3[] player_pos_ini_return = { new Vector3(85.5f, 0.5f, -36f), new Vector3(33f, 0.5f, -54.5f), new Vector3(85.5f, 0.5f, -8f), new Vector3(81f, 0.5f, -30.5f)};

    // inicia derecha, derecha, abajo, derecha, arriba
    public Vector3[] player_direction_ini_next = { new Vector3(1f, 0f, 1f), new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, -1f), new Vector3(1f, 0f, 0f), new Vector3(0f, 0f, 1f)};
    public void getOnRail(bool isVertical, Vector3 position) {
        railVertical = isVertical;
        onRail = true;
        //The direccion depends on the type of the rail
        if (isVertical)
        {
            //Vertical 
            this.direction = new Vector3(0f, 0f, this.direction.z);
            GetComponent<Rigidbody>().position = new Vector3(position.x, currentPos.y, currentPos.z);
        }
        else {
         //   Debug.Log("Es horizontal" + position );
        //Horizontal
        this.direction = new Vector3(this.direction.x, 0f, 0f); 
        GetComponent<Rigidbody>().position = new Vector3(currentPos.x, currentPos.y, position.z); 
        }
        this.speed = 5f;
        GetComponent<Rigidbody>().velocity = speed * direction;
        currentPos = (GetComponent<Rigidbody>().position);
    }
    public void getOffRail() {
        // The direccion depends on the type of the rail  (vector's direction and sense)
        if (railVertical) {
            this.direction = new Vector3(1f, 0f, this.direction.z);
        }
        else this.direction = new Vector3(this.direction.x, 0f, 1f);
        this.speed = 10f;
        onRail = godMode = false;
        GetComponent<Rigidbody>().velocity = speed * direction;
        //chickPerSecond = 3.0f;
    }



    void Start()
    {
        ScriptGameState gState = GameObject.Find("GameState").GetComponent<ScriptGameState>();
        int last_lvl = gState.last_level;
        int lvl = gState.level;
        
        //Back
        if (last_lvl <= lvl) {
            // goNext
           this.transform.position = player_pos_ini_next[lvl - 1];
           this.direction = player_direction_ini_next[lvl - 1];
        }
        else
        { //last_lvl > lvl 
          //goBack
            //Debug.Log("level posicion es" + player_pos_ini_return[lvl - 1]);
            this.transform.position = player_pos_ini_return[lvl - 1];
            //Debug.Log("level direccion" + player_direction_ini_next[lvl] * -1);
            this.direction = player_direction_ini_next[lvl] * -1;// tenemos que volver con el sentido contrario al de nivel siguiente
        }

        //this.direction = new Vector3(1f, 0f, 1f);
        this.speed = 10f;
        gState.lastCheckPointIs_Pos_ini_change_Level = true;
        gState.lastCheckPointPos = currentPos = this.transform.position;
        gState.lastCheckPoint_change_level_player_direction = this.direction;
        //Debug.Log("la pos_inicial es" + this.transform.position);
        //Importante se ha de inicializar tambien la posicion del RigidBody ademas de la transform.position
        //por que sino genera bugs en los cambios de nivel
        GetComponent<Rigidbody>().position = currentPos;
        GetComponent<Rigidbody>().velocity = speed * direction;
        onRail = deleteSnake = false;
        //playerParticle = GetComponent<ParticleSystem>();
        playerParticle.Stop();
        speedParticle.Stop();

    }


    void Update()
    {
        previousTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && previousTime > (1.0f / chickPerSecond))
        {
            if (onRail) {
            
               if (railVertical) this.direction.z *= -1;
                //if (this.direction.z != 0) this.direction.z *= -1;
               else this.direction.x *= -1;
               GetComponent<Rigidbody>().velocity = speed * direction;
               previousTime = 0.0f;
            } 
            else {
                Vector3 act = playerParticle.transform.position;
                playerParticle.transform.position = new Vector3(currentPos.x - direction.x * 0.8f, currentPos.y, currentPos.z + direction.z * 0.8f);
                direction.z *= -1;
                GetComponent<Rigidbody>().velocity = speed * direction;
                previousTime = 0.0f;
                playerParticle.Play();
                AudioSource.PlayClipAtPoint(shootSound, GetComponent<Rigidbody>().position);
            }
            //Debug.Log("dentro");
        }
        else if (Input.GetKey(KeyCode.S) && previousTime > (1.0f / chickPerSecond-1))
        {
            GetComponent<Rigidbody>().velocity = (speed+2) * direction;
            Vector3 pos = GetComponent<Rigidbody>().position;
            GetComponent<Rigidbody>().position = new Vector3(pos.x+(float)Math.Sin(Time.time*0.1f)*0.2f, pos.y, pos.z+(float)Math.Sin(Time.time * 0.1f) * 0.2f); //speed and amount
            speedParticle.transform.position = new Vector3(currentPos.x - direction.x*0.8f, currentPos.y, currentPos.z + direction.z * 0.8f);
            speedParticle.Play();
            previousTime = 0.0f;

        }
        else if(Input.GetKey(KeyCode.P) && previousTime > 1.0f)
        {
            previousTime = 0.0f;
            godMode = !godMode;
        }
        currentPos = GetComponent<Rigidbody>().position;
        //Debug.Log(currentPos)
    }

    //se ejecuta cuando entra en colision con un Box Collider 
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
        GetComponent<Rigidbody>().velocity = speed * direction;
        AudioSource.PlayClipAtPoint(touchSound, currentPos);

        if (collision.collider.gameObject.CompareTag("SnakeBody") && !deleteSnake)
        {
            deleteSnake = true;
            //restart the game
            GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeMovement>().destroySnake();
            ScriptGameState.onlyinst.quad = 2;
            ScriptGameState.onlyinst.cameraPos = new Vector3(27f, 18.321f, -7.5f);
            ScriptGameState.onlyinst.restart();
        }
        else deleteSnake = false;
        if (collision.collider.gameObject.CompareTag("Key")) {

            if (collision.collider.gameObject.CompareTag("Key"))
            {
                GameObject.Find("GameState").GetComponent<ScriptGameState>().KeyCollected();
            }
        }
        if (collision.collider.gameObject.CompareTag("RoughWall")) {
            if (!godMode)
            {
                Stop();
                GameObject.Find("GameState").GetComponent<ScriptGameState>().restart();
            }
        }
    }
    public void Stop() {
        GetComponent<Rigidbody>().velocity = 0 * direction; // asignando defrente 0, el speed no lo ponemos a cero para no perder su valor al volver a recolocar el player.
    }
    public void Continue() {
        GetComponent<Rigidbody>().velocity = speed* direction;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("trigger-player: " + other.gameObject.name);
    //}

    public int getQuadrant(Vector3 pos)
    {
        int x = (int)(pos.x/19)+1;
        int z = (int)(pos.z / -15)+1;
        //Debug.Log("getQuadrant: " + x + " " + z);
        if (z == 1) return x;
        else if (z == 2) return x+5;
        else if (z == 3) return x+10;
        return x+15;
    }


}
