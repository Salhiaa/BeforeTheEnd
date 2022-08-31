using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    private TMPro.TextMeshProUGUI TMP;

    private void Awake()
    {
        TMP = GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
    }

    public void Say(string line, bool endLine){
        if(!gameObject.activeSelf){
            gameObject.SetActive(true);
        }
        if (endLine){
            gameObject.SetActive(false);
        } else
        {
            TMP.text = line;
        }
    }
}
