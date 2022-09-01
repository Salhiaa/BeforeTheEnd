using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeur : Interactable
{
    public Sprite itemSprite;
    void Awake()
    {
        if (GameManager.Instance.dancerAwakened)
            MoveHeart();
        else if (GameManager.Instance.gotHeart)
            gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if (!GameManager.Instance.gotHeart) {
            GameManager.Instance.PickItem("Heart", itemSprite);
            GameManager.Instance.gotHeart = true;
            gameObject.SetActive(false);
        }
    }

    public void MoveHeart()
    {
        GetComponent<Transform>().position = new Vector3(5.83f, -0.73f, 0);
    }
}
