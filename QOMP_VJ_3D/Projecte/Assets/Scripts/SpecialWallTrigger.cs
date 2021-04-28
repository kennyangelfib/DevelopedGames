using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWallTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        TargetSpecialWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public GameObject TargetSpecialWall;
    //public bool isActive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MyPlayer"))
        {
            this.ChangeStates();  
        }
    }
    public void ChangeStates()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        TargetSpecialWall.SetActive(!TargetSpecialWall.gameObject.activeSelf);
    }
}
