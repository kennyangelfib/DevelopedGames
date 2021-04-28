using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesWallScript : MonoBehaviour
{
    public TextMeshPro TextObj;
    // Start is called before the first frame update
    public int lives;
    void Start()
    {
        // lives = 3;
        writeLives();
    }

    // Update is called once per frame

    private void writeLives() {
        if (TextObj != null)
        {
            String text_lives = "";
            switch (lives)
            {
                case 1: text_lives = "I"; break;
                case 2: text_lives = "I I"; break;
                case 3: text_lives = "I I I"; break;
            }
            TextObj.text = text_lives;
        }
    }


    public void decreaselive()
    {
        if (lives - 1 > 0) {
            lives--;
            writeLives();
        }
        else {
            Destroy(TextObj);
            Destroy(this.gameObject);
        }
    }
}
