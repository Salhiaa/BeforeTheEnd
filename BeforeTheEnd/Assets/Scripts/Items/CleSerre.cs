using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleSerre : Interactable
{
    public Sprite itemSprite;

    private void Awake()
    {
        if (GameManager.Instance.gotKey)
            Destroy(gameObject);
    }

    public override void Interact()
    {
        GameManager.Instance.PickItem("KeyCage", itemSprite);
        GameManager.Instance.gotKey = true;
        Destroy(gameObject);
    }
}
