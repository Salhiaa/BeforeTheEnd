using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkObjectToggler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle(){
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }
}
