using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Interactable
{
    private Vector3 targetLocation = new Vector3(-3.7f, -2.24f, 0);
    public bool slideDown;
    public GameObject ladder;

    
    void Update()
    {
        if (slideDown)
        {
            ladder.transform.position = Vector3.MoveTowards(ladder.transform.position, targetLocation, .10f);
            if (ladder.transform.position == targetLocation)
            {
                ladder.GetComponent<EdgeCollider2D>().enabled = enabled;
                Destroy(gameObject);
            }
        }
    }

    public override void Interact()
    {
        //print("Hey, jusque-là ça marche !");
        slideDown = true;
    }
}
