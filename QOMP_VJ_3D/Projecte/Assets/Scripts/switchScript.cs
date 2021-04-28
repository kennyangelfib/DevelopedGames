using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    public GameObject switchObj;
    public GameObject[] TargetBlocks;
    public bool isActive;
    public bool isTypeButtonOn;
    // Start is called before the first frame update
    void Start()
    {
        if (isActive){
            for (int i = 0; i < TargetBlocks.Length; ++i)
                if (isTypeButtonOn) TargetBlocks[i].SetActive(true);
                else TargetBlocks[i].SetActive(false);
        }
        else this.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
        switchObj.GetComponent<switchScript>().changeStateTargetBlock();
    }

    public void changeStateTargetBlock()
    {
        for (int i = 0; i < TargetBlocks.Length; ++i)
            TargetBlocks[i].SetActive(!TargetBlocks[i].activeSelf);
            Invoke("changeActive", 0.1f);

    }
    public void changeActive() { 
        this.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
