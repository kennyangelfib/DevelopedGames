using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class auxiliarTestScript : MonoBehaviour
{
    // Start is called before the first frame update


    void renamingObjects() {
        //Renombreamos todos los objetos de Wall una vez hemos aplicado los box colliders de manera corecta.
        GameObject[] a = GameObject.FindGameObjectsWithTag("Wall");

        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].GetComponent<BoxCollider>() != null)
            {

                //&& a[0].name == "wall_NoBoxCollider(Clone)"
                a[i].name = "wall_BoxCollider";
                count++;
                ///Debug.Log("The " + a[0].name + " doesn't have component Cloth");
            }
            else
            {
                a[i].name = "wall_No_BoxCollider";
            }

        }
        Debug.Log("The number of colliders of Wall" + +count);
        GameObject[] b = GameObject.FindGameObjectsWithTag("RoughWall");
        count = 0;
        string tmpname = "";
        for (int i = 0; i < b.Length; i++)
        {
            //Debug.Log("i es : " + i);

            switch (b[i].name)
            {
                case "rough_right(Clone)": tmpname = "rough_right"; break;
                case "rough_left(Clone)": tmpname = "rough_left"; break;
                case "rough_up(Clone)": tmpname = "rough_up"; break;
                case "rough_down(Clone)": tmpname = "rough_down"; break;
            }
            if (b[i].GetComponent<BoxCollider>() != null)
            {
                //&& a[0].name == "wall_NoBoxCollider(Clone)"
                b[i].name = tmpname + "_BoxCollider";
                count++;
                ///Debug.Log("The " + a[0].name + " doesn't have component Cloth");
            }
            else
            {
                b[i].name = tmpname + "_No_BoxCollider";
            }
        }
        Debug.Log("The number of colliders of RoughWall" + count);

    }

    public Material[] materiales = new Material[15];
    private void aplymaterials() {

        StreamReader sw = new StreamReader("C:\\Users\\kenny\\Desktop\\VJ\\VJ_lab\\3D_develop\\POMG\\Assets\\Scripts\\old\\level2_material.txt");

        string line = sw.ReadLine();
        int filas = int.Parse(line);
        line = sw.ReadLine();
        int columnas = int.Parse(line);
        char[,] texto = new char[filas, columnas];
        for (int i = 0; i < filas; i++)
        {
            line = sw.ReadLine();
            for (int j = 0; j < columnas; j++)
            {
                texto[i, j] = line[j];
            }
        }
        sw.Close();

        GameObject[] a = GameObject.FindGameObjectsWithTag("Wall");

        for (int i = 0; i < a.Length; i++)
        {
            int fil = (int)((a[i].transform.position.z) * -1 - 0.5f);
            int col = (int)(a[i].transform.position.x - 0.5f);
            Debug.Log("Fila, columna: " + fil + " " + col);
            //Debug.Log("Soy material " + a[i].GetComponent<Renderer>().material.name);
            Debug.Log("numero" + (char)texto[fil, col]);
            a[i].GetComponent<Renderer>().material = materiales[texto[fil, col] - 'a'];
        }
       
    }
   
    void Start()
    {
        renamingObjects();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
