using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileMapComponent : MonoBehaviour
{
    public GameObject tile, paddle, roughWall_Right, roughWall_Left, roughWall_Up, roughWall_Down;
    public int level;
    private List <GameObject> tileMap = new List<GameObject>();

    int mapWidth = 20;
    int mapHeight = 10;
    float tileOffset = 1.00f;
    void Start()
    {
       // createQuadTileMap();
       // createPaddles();
		loadLevel();
    }


    void createQuadTileMap()
    {
        GameObject tmp;
        for (int x=0; x<=mapWidth; ++x)
        {
            for (int z = 0; z <= mapHeight; ++z)
            {
                tmp = Instantiate(tile);
                tmp.transform.position = new Vector3(-30+x * tileOffset, 0, 7+z * tileOffset);
                
                tmp.transform.parent = transform;
                tmp.name = x.ToString() + "," + z.ToString();

                tileMap.Add(tmp);
            }
        }
    }

    void createPaddles()
    {
        GameObject tmp = Instantiate(paddle);
        tmp.transform.position = new Vector3(-30 + 1, 1, 7+5);
        tmp.transform.parent = transform;

        tmp = Instantiate(paddle);
        tmp.transform.position = new Vector3(-30+19, 1,  7 + 5);
        tmp.transform.parent = transform;

    }


    private void Update()
    {
        //tileMap[0].transform.position = new Vector3(-1 * tileOffset, 0, 0 * tileOffset);
        //tileMap[0].transform.eulerAngles = new Vector3(0, 0, 0);

    }
    private void loadLevel()
    {
        string line;


        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\kenny\Desktop\VJ\VJ_lab\3D_develop\POMG\Assets\Scripts\tileMaps\level"+level +".txt");



        /*while ((line = file.ReadLine()) != null)
		{
		}*/
        line = file.ReadLine();
        if (string.Compare(line, 0, "TILEMAP", 0, 7) != 0)
            Debug.Log("No es un tilemap");
        //COLUMNAS
        line = file.ReadLine();
        int columnas = int.Parse(line);
        //FILAS
        line = file.ReadLine();
        int filas = int.Parse(line);
        GameObject tmp;
        for (int i = 0; i < filas; i++)
        {
            line = file.ReadLine();
            int cols = 0;
            for (int j = 0;  cols < columnas && j < line.Length; j++)
            {
                //Debug.Log("innerloop" + line );
                switch (line[j])
                {
                    case 'w':
                        tmp = Instantiate(tile);
                        tmp.transform.position = new Vector3(0.5f + cols, 0.5f, -0.5f - i);
                        cols++;
                        break;
                    case 'p':
                        j++;
                        switch (line[j]) {
                            case 'u':
                                tmp = Instantiate(roughWall_Up);
                                tmp.transform.position = new Vector3(tmp.transform.position.x+cols, tmp.transform.position.y, tmp.transform.position.z - i );
                                break;
                            case 'd':
                                tmp = Instantiate(roughWall_Down);
                                tmp.transform.position = new Vector3(tmp.transform.position.x + cols, tmp.transform.position.y, tmp.transform.position.z - i);
                                break;
                            case 'l':
                                tmp = Instantiate(roughWall_Left);
                                tmp.transform.position = new Vector3(tmp.transform.position.x + cols, tmp.transform.position.y, tmp.transform.position.z - i);
                                break;
                            case 'r':
                                tmp = Instantiate(roughWall_Right);
                                tmp.transform.position = new Vector3(tmp.transform.position.x + cols, tmp.transform.position.y, tmp.transform.position.z - i);
                                break;
                            default:
                                Debug.Log("Unexpected caracter after 'p'");
                                break;
                        }
                        cols++;
                        Debug.Log("Es un roughWall");
                        break;
                    default:
                        cols++;
                        break;
                }
            }
        }
        file.Close();
    }
}
//1.0115

