using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeur : MonoBehaviour
{
    private GameObject GM;
    bool playerCanInteract;

    void Awake()
    {
        GM = GameObject.Find("GameManager");
        if (GM.GetComponent<GameManager>().gotHeart == true) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerCanInteract)
        {
            GM.GetComponent<GameManager>().pickHeart();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCanInteract = false;
        }
    }
}
