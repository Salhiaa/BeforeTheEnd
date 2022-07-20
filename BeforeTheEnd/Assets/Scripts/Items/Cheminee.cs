using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheminee : MonoBehaviour
{
    private GameObject GM;
    private bool playerCanInteract;
    public Sprite litSprite;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        if (GM.GetComponent<GameManager>().fireplaceLit) gameObject.GetComponent<SpriteRenderer>().sprite = litSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerCanInteract && GM.GetComponent<GameManager>().item=="torche"){
            GM.GetComponent<GameManager>().LightFireplace();
            gameObject.GetComponent<SpriteRenderer>().sprite = litSprite;
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
