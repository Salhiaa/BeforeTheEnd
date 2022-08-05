using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Interactable
{
    public GameObject Plant;
    public GameObject Sprout;
    public Jardinier Gardener;

    private void Awake()
    {
        if (GameManager.Instance.plantGrew)
            Plant.SetActive(true);
        else if (GameManager.Instance.usedSeeds)
            Sprout.SetActive(true);
    }

    public override void Interact()
    {
        if (GameManager.Instance.item2 == "Seeds")
        {
            print("Seeds ok");
            GameManager.Instance.UseItem("Seeds");
            GameManager.Instance.usedSeeds = true;
            if (GameManager.Instance.item == "FullBottle") 
            {
                GrowPlant();
            } else
            {
                Sprout.SetActive(true);
            }
        }
        if (GameManager.Instance.item=="FullBottle"){
            if (GameManager.Instance.usedSeeds)
            {
                Sprout.SetActive(false);
                GrowPlant();
            } else {
                GameManager.Instance.PickItem("EmptyBottle", Gardener.itemSprite, "FullBottle");
            }
        }
    }

    private void GrowPlant()
    {
        Plant.SetActive(true);
        GameManager.Instance.UseItem("FullBottle");
        GameManager.Instance.plantGrew = true;
    }
}
