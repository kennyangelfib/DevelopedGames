using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotWallHorizontal : MonoBehaviour
{
    public GameObject dotWall, miniWallPrefab;
    public bool close = false;

    private void OnTriggerExit(Collider other)
    {
        if (this.tag.Equals("DotWall2") && !close)
        {
            close = true;
            GameObject.Find("GameState").GetComponent<ScriptGameState>().closeDotWall2 = true;
            foreach (Transform child in dotWall.transform)
            {
                Destroy(child.gameObject);
            }
            GameObject go = Instantiate(miniWallPrefab);
            go.transform.position = new Vector3(78.5f, 0.5f, -28.5f);
            go.transform.Rotate(0, 90, 0);
        }
    }


}
