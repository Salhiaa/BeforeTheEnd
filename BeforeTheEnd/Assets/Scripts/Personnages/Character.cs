using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Interactable
{
    // Textbox info
    [Header("Speech Box")]
    public Monologue speechBox;
    //private TMPro.TextMeshProUGUI TMP;
    protected int linesIndex = 0;
    protected string[] currentArray;

    // Player input
    protected PlayerMovement player;

    // Power given
    [Header("Power indication")]
    public GameObject PowerIndication;

    // Start is called before the first frame update
    void Start()
    {
        //TMP = speechBox.GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public override void Interact()
    {
        // Première ligne
        if (linesIndex == 0)
        {
            //speechBox.SetActive(true);

            // Stop player movement during dialogue
            player.switchToDialogue();


            //TMP.text = currentArray[0];
            //linesIndex++;
        }
        // Dernière ligne de texte
        //else if (linesIndex == currentArray.Length && !PowerToGrant)
        //{
        /*speechBox.SetActive(false);
        if (!PowerToGrant) {*/
        //EndDialogue();
        //}
        //}
        /*else
        {
            TMP.text = currentArray[linesIndex];
        }*/
        linesIndex++;
    }

    // Give player movement back
    protected void EndDialogue()
    {
        player.switchToMovement();
    }
}
