using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacDeGraines : Interactable
{
    public Sprite itemSprite;
    private void Awake()
    {
        if (GameManager.Instance.gotSeeds)
            Destroy(gameObject);
    }

    public override void Interact()
    {
        if (GameManager.Instance.gotBottle)
        {
            GameManager.Instance.PickItem("Seeds", itemSprite);
            GameManager.Instance.gotSeeds = true;
            Destroy(gameObject);
        }
    }
}
