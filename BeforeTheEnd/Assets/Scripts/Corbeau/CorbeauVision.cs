using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorbeauVision : MonoBehaviour
{
    public CorbeauMovement lePiaf;
    GameObject GM;
    public GameObject[] toggleableObjects;

    private void Start()
    {
        GM = GameObject.Find("GameManager");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GM.GetComponent<GameManager>().canUseVision == true)
        {
            Toggle();
            GameObject.Find("Player").GetComponent<SFXManager>().PlayCrow1();
            GameObject.Find("Player").GetComponent<SFXManager>().PlayVision();
        }
    }

    private void Toggle(){
        if (lePiaf.isUsingVision){
            lePiaf.Rest();
            foreach (GameObject toggleableObject in toggleableObjects)
            {
                toggleableObject.SetActive(false);
            }
        }

        if(!lePiaf.isUsingVision && !lePiaf.wantsToRest){
            lePiaf.isUsingVision = true;
            foreach (GameObject toggleableObject in toggleableObjects)
            {
                toggleableObject.SetActive(true);
            }
        }
    }
}