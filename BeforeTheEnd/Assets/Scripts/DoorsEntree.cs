using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsEntree : MonoBehaviour
{
    public GameObject serre;
    public GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        if (!GM.GetComponent<GameManager>().fireplaceLit){
            serre.GetComponent<Door>().isLocked=true;
        }
        else{
            serre.GetComponent<Door>().isLocked=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lit(){
        serre.GetComponent<Door>().isLocked=false;
    }
}
