using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torche : MonoBehaviour
{
    private GameObject GM;
    private bool playerCanInteract = false;

    private void Awake() {
        GM = GameObject.Find("GameManager");
        if (GM.GetComponent<GameManager>().torchPickedUp==true) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && GM.GetComponent<GameManager>().alreadyVisitedEntree && playerCanInteract){
            GM.GetComponent<GameManager>().PickTorch();
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
