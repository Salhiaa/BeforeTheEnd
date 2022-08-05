using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheminee : Interactable
{
    public Sprite litSprite;
    public Door GreenhouseDoor;

    void Awake()
    {
        if (!GameManager.Instance.Darkness)
        {
            FireplaceLit();
        } else
        {
            GameManager.Instance.Darkness.SetActive(true);

            if (!GameManager.Instance.alreadyVisitedEntree)
            {
                GameManager.Instance.alreadyVisitedEntree = true;
            }
            
        }
    }

    // Update is called once per frame
    public override void Interact()
    {
        if(GameManager.Instance.item=="Torch"){
            FireplaceLit();
            GameManager.Instance.UseItem("Torch");
            Destroy(GameManager.Instance.Darkness);
        }
    }

    private void FireplaceLit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = litSprite;
        GreenhouseDoor.isLocked = false;
    }
}
