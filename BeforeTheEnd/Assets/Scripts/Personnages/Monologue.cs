using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public GameObject MonologueBox;

    void Awake()
    {
        MonologueBox.SetActive(false);
    }

    public void Say(string line, bool endLine){
        MonologueBox.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text=line;
        if(!MonologueBox.activeSelf){
            MonologueBox.SetActive(true);
        }
        if(endLine){
            MonologueBox.SetActive(false);
        }
    }
}
