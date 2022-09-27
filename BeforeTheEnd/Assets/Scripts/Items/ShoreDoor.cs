using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoreDoor : Door
{
    public override void Interact()
    {
        if (GameManager.Instance.item == "ShoreKey")
        {
            base.Interact();
        } else
        {
            print("You haven't got the key");
        }
    }
}
