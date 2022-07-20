using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorbeauTalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Talk(string parole){
        //Afficher parole
    }

    void TalkSurrealiste(string parole, GameObject objet){
        //Afficher parole
        objet.GetComponent<TalkObjectToggler>().Toggle();
    }
}
