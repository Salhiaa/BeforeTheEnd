using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionObjectToggler : MonoBehaviour
{

    public bool visible = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle(){
        if(visible){
            visible = false;
            gameObject.SetActive(false);
        }
        else{
            visible = true;
            gameObject.SetActive(true);
        }
    }
}
