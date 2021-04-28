using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject switchObj;
    private bool SwOnLeft, open, first;
    private Vector3 posLeft, posRight;
    private int rotY;
    GameObject[] topRightBlocks, bottomBlocks;


    void Start()
    {
        posLeft = new Vector3(19.5f, 0, -22.5f);
        posRight = new Vector3(33.5f, 0, -22.5f);
        rotY = 90;
        SwOnLeft = first = true;
        open = false;
        topRightBlocks = GameObject.FindGameObjectsWithTag("TopRightBlocks");
        bottomBlocks = GameObject.FindGameObjectsWithTag("BottomBlocks");
    }

    void Update()
    {
        //++ticks;
        //if (ticks == 60)
        //{
        //    ticks = 0; acceptCol = true;
        //}
        if (first)
        {
            first = false;
            for (int i = 0; i < bottomBlocks.Length; ++i)
                bottomBlocks[i].SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(this.gameObject.name + " "+ this.gameObject.transform.position);
        if (this.gameObject.name.Equals("buttonOn"))
        {
            if (SwOnLeft) //buttonOn move to right
            {
                SwOnLeft = false;
                this.transform.position = posRight;
                this.transform.eulerAngles = new Vector3(0, -rotY, 0);
                switchObj.transform.position = posLeft;
                switchObj.transform.eulerAngles = new Vector3(0, rotY, 0);
            }
            else
            {
                SwOnLeft = true;
                this.transform.position = posLeft;
                this.transform.eulerAngles = new Vector3(0, rotY, 0);
                switchObj.transform.position = posRight;
                switchObj.transform.eulerAngles = new Vector3(0, -rotY, 0);
            }

            if (!open){
                open = true;
                for (int i = 0; i < topRightBlocks.Length; ++i)
                    topRightBlocks[i].SetActive(false);
                for (int i = 0; i < bottomBlocks.Length; ++i)
                    bottomBlocks[i].SetActive(true);
            }
            else
            {
                open = false;
                for (int i = 0; i < topRightBlocks.Length; ++i)
                    topRightBlocks[i].SetActive(true);
                for (int i = 0; i < bottomBlocks.Length; ++i)
                    bottomBlocks[i].SetActive(false);

            }

        }
        //else if (this.gameObject.name.Equals("buttonOff"))
        //{
        //    if (SwOnLeft) //buttonOff move to left
        //    {
        //        SwOnLeft = false;
        //        this.transform.position = posLeft;
        //        this.transform.eulerAngles = new Vector3(0, rotY, 0);
        //        switchObj.transform.position = posRight;
        //        switchObj.transform.eulerAngles = new Vector3(0, -rotY, 0);
        //    }
        //    else
        //    {
        //        SwOnLeft = true;
        //        this.transform.position = posRight;
        //        this.transform.eulerAngles = new Vector3(0, -rotY, 0);
        //        switchObj.transform.position = posLeft;
        //        switchObj.transform.eulerAngles = new Vector3(0, rotY, 0);
        //    }
        //}
        //}
    }

}
