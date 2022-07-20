using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHeart : MonoBehaviour
{
    private GameObject GM;
    public GameObject Dancer;
    public GameObject heart;
    bool playerCanInteract;

    void Awake()
    {
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GM.GetComponent<GameManager>().gotHeart && playerCanInteract)
        {
            heart.GetComponent<Transform>().position = new Vector3(5.83f, -0.73f, 0);
            heart.SetActive(true);
            GM.GetComponent<GameManager>().AwakenDancer();
            Dancer.GetComponent<DanseuseD>().WakeUp();
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
