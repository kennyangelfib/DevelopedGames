using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class DotWallVertical : MonoBehaviour
{
    public GameObject dotWall, miniWallPrefab;
    bool first = true;

    private void OnTriggerEnter(Collider other)
    {
        if (this.tag.Equals("DotWall1") && first)
        {
            first = false;
            foreach (Transform child in dotWall.transform)
            {
                Destroy(child.gameObject);
            }

            GameObject go = Instantiate(miniWallPrefab);
            go.transform.position = dotWall.transform.position - new Vector3(0.1f,0,0);

           // go.transform.position = new Vector3(35.8f, 0.5f, -37.5f);
        }
    }
}
