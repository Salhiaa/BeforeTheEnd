using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeEmplacement : Interactable
{
    public GameObject Key;

    public override void Interact()
    {
        Key.SetActive(true);
        Destroy(gameObject);
    }
}
