using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseuseD : Character
{
    [Header("Speech components")]
    //[SerializeField] Monologue speechBox;
    [SerializeField] Dialogue dial;
    //uint linesIndex;

    [Header("First Interaction")]
    [SerializeField] string BeforeAwakening;

    [Header("When Awakened")]
    [SerializeField] Sprite awakened;
    [SerializeField] string[] Awakening;
    bool isAwake;

    /*[Header("Power Info")]
    public GameObject CrowsWings;

    [Header("Player Movement")]
    [SerializeField] PlayerMovement player;*/

    void Awake()
    {
        if (GameManager.Instance.dancerAwakened == true)
            WakeUp();
    }

    //---gestion du dialogue---
    public override void Interact()
    {
        // --- Monologue : After awakening --- //
        if (isAwake)
        {
            if (linesIndex <= Awakening.Length - 1)
            {
                dial.Say(Awakening[linesIndex]);
                //linesIndex++;
            }
            else if (linesIndex == Awakening.Length) //fin de l'interaction
            {
                //linesIndex++;
                //hide speechbox
                speechBox.Say("", true);
                //show power indication
                PowerIndication.SetActive(true);
                //grant power
                GameManager.Instance.canFetchObject = true;
            }
            else //hide power indication
            {
                PowerIndication.SetActive(false);
                EndDialogue();
            }
        }
        // --- Monologue : First Interaction --- //
        else
        {
            if (linesIndex == 0)
            {
                speechBox.Say(BeforeAwakening, false);
                //linesIndex++;
            } else
            {
                speechBox.Say("", true);
                EndDialogue();
            }
            
        }

        base.Interact();
    }

    public void WakeUp()
    {
        linesIndex = 0;
        GetComponent<SpriteRenderer>().sprite = awakened;
        isAwake = true;
    }
}
