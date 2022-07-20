using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private GameObject GM;
    private bool playerCanInteract = false;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        if (GM.GetComponent<GameManager>().plantGrew){
            GameObject.Find("TroncPlante").SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && GM.GetComponent<GameManager>().item=="Seeds" && playerCanInteract){
            print("Seeds ok");
        }
        if(Input.GetKeyDown(KeyCode.E) && GM.GetComponent<GameManager>().item2=="FullBottle" && playerCanInteract){
            print("bouteille ok");
        }
        if(Input.GetKeyDown(KeyCode.E) && GM.GetComponent<GameManager>().item2=="FullBottle" && GM.GetComponent<GameManager>().item=="Seeds" && playerCanInteract){
            GM.GetComponent<GameManager>().GrowPlant();
            print("combo ok");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.name == "Player")
        {
            playerCanInteract=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player")
        {
            playerCanInteract=false;
        }
    }
}
