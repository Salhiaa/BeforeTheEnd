using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GiveHeart : Interactable
{
    public DanseuseD Dancer;
    public GameObject heart;

    public override void Interact()
    {
        if (GameManager.Instance.item == "Heart")
        {
            heart.GetComponent<Coeur>().MoveHeart();
            heart.SetActive(true);
            GameManager.Instance.UseItem("Heart");
            GameManager.Instance.dancerAwakened = true;
            Dancer.WakeUp();
        }
    }
}
