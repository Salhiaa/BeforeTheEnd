using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Interactable
{
    private Vector3 targetLocation = new Vector3(-3.7f, -2.24f, 0);
    public bool slideDown;
    public GameObject ladder;
    private float speed = .10f;

    private void Start()
    {
        if (GameManager.Instance.gotLadderDown)
        {
            ladder.transform.position = targetLocation;
            EndMovement();
        }
    }

    void FixedUpdate()
    {
        if (slideDown)
        {
            // ladder movement
            ladder.transform.position = Vector3.MoveTowards(ladder.transform.position, targetLocation, speed);
            if (ladder.transform.position == targetLocation)
            {
                EndMovement();
                GameManager.Instance.gotLadderDown = true;
            }
            speed += .02f; // increases falling speed for a more natural effect
        }
    }

    public override void Interact()
    {
        slideDown = true;
    }

    public void EndMovement()
    {
        ladder.GetComponent<EdgeCollider2D>().enabled = enabled; // enable collider for climbing the ladder
        Destroy(gameObject);
    }
}
