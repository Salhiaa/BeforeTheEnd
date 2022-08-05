using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseuseD : Interactable
{
    [Header("Speech components")]
    [SerializeField] Monologue speechBox;
    [SerializeField] Dialogue dial;
    uint linesIndex;

    [Header("First Interaction")]
    [SerializeField] string BeforeAwakening;

    [Header("When Awakened")]
    [SerializeField] Sprite awakened;
    [SerializeField] string[] Awakening;
    bool isAwake;

    [Header("Power Info")]
    public GameObject CrowsWings;
    
    

    void Awake()
    {
        if (GameManager.Instance.dancerAwakened == true)
            WakeUp();
    }

    //---gestion du dialogue---
    public override void Interact()
    {
        //Awakening
        if (isAwake)
        {
            if (linesIndex <= Awakening.Length - 1)
            {
                dial.Say(Awakening[linesIndex]);
            }
            else if (linesIndex == Awakening.Length) //fin de l'interaction
            {
                //hide speechbox
                speechBox.Say("", true);
                //show power indication
                CrowsWings.SetActive(true);
                //grant power
                GameManager.Instance.canUseVision = true;
            }
            else //hide power indication
            {
                CrowsWings.SetActive(false);
            }
            linesIndex++;
        }
        //Before Awakening
        else
        {
            if (linesIndex == 0)
            {
                speechBox.Say(BeforeAwakening, false);
                linesIndex++;
            } else
            {
                speechBox.Say("", true);
            }
            
        }
    }

    public void WakeUp()
    {
        GetComponent<SpriteRenderer>().sprite = awakened;
        isAwake = true;
    }
}
