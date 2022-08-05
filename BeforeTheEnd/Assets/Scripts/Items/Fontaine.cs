using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fontaine : Interactable
{
    public Sprite itemSprite;
    public override void Interact()
    {
        if(GameManager.Instance.item=="EmptyBottle"){
            GameManager.Instance.PickItem("FullBottle", itemSprite, "EmptyBottle");
        }
    }
}
