using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseuseD : MonoBehaviour
{
    public Sprite[] etatDanseuseD;
    [SerializeField] SpriteRenderer srDanseuse;

    [SerializeField] string BeforeAwakening;
    [SerializeField] string[] Awakening;

    [SerializeField] Monologue speechBox;
    [SerializeField] Dialogue dial;

    private GameObject GM;
    public GameObject CrowsWings;

    uint linesIndex;
    bool playerCanInteract;
    public bool awakened;

    void Awake()
    {
        GM = GameObject.Find("GameManager");

        if (GM.GetComponent<GameManager>().dancerAwakened == true) {
            WakeUp();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //---gestion du dialogue---
        if (playerCanInteract && Input.GetKeyDown(KeyCode.E))
        {
            //Awakening
            if (awakened)
            {
                if (linesIndex <= Awakening.Length - 1) { 
                    dial.Say(Awakening[linesIndex]);
                    linesIndex++;
                }
                else if (linesIndex == Awakening.Length) //fin de l'interaction
                {
                    //hide speechbox
                    speechBox.Say("", true);
                    //show power indication
                    CrowsWings.SetActive(true);
                    //grant power
                    GM.GetComponent<GameManager>().canUseVision = true;
                }
                else //hide power indication
                {
                    CrowsWings.SetActive(false);
                }
            }
            //Before Awakening
            else
            {
                speechBox.Say(BeforeAwakening, false);
            }
        }
    }

    public void WakeUp() {
        srDanseuse.sprite = etatDanseuseD[1];
        awakened = true;
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
            dial.clear();
            speechBox.Say("", true);
            linesIndex = 0;
        }
    }
}
