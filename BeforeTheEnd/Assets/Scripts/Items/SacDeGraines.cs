using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacDeGraines : MonoBehaviour
{
    private GameObject GM;
    private bool playerCanInteract = false;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        if (GM.GetComponent<GameManager>().gotSeeds) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && GM.GetComponent<GameManager>().item=="" && playerCanInteract){
            GM.GetComponent<GameManager>().pickSeeds();
            Destroy(gameObject);
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
