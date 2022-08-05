using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torche : Interactable
{
    public Sprite itemSprite;

    private void Awake() {
        if (GameManager.Instance.Darkness)
            GameManager.Instance.Darkness.SetActive(false);
        if (GameManager.Instance.torchPickedUp)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        if(GameManager.Instance.alreadyVisitedEntree)
        {
            GameManager.Instance.PickItem("Torch", itemSprite);
            GameManager.Instance.torchPickedUp = true;
            Destroy(gameObject);
        }
    }
}
