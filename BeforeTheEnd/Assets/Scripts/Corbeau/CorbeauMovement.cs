using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CorbeauMovement : MonoBehaviour
{
    [SerializeField] Transform ravenRestPos;

    public bool wantsToRest = false;
    public bool isUsingVision, isAtCelling;

    [SerializeField] Transform centerCelling;

    private void FixedUpdate()
    {
        // Revient sur la Tete
        if (wantsToRest && (transform.position != ravenRestPos.position))
        {
            isUsingVision = false;
            transform.position = Vector3.MoveTowards(transform.position, ravenRestPos.position, .15f);
        } else if (wantsToRest && transform.position == ravenRestPos.position) // Quand est sur la tete, arrete de vouloir etre sur la tete
        {
            isAtCelling = false;
            wantsToRest = false;
        }

        // Va au plafond
        if (!isAtCelling && isUsingVision && transform.position != centerCelling.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerCelling.position, .15f);
        } else if (isUsingVision && transform.position == centerCelling.position) // Quand est au plafond, arrete de vouloir allez au plafond
        {
            isAtCelling = true;
            transform.SetParent(null);
        }
    }

    public void Rest()
    {
        if(transform.position != ravenRestPos.position)
        {
            transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            wantsToRest = true;
        }
    }
}
