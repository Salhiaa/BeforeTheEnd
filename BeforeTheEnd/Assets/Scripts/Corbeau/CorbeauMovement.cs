using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CorbeauMovement : MonoBehaviour
{
    [SerializeField] Transform RestPos;
    [SerializeField] Transform centerCelling;

    [SerializeField] Animator animCrow;

    public bool wantsToRest = false;
    public bool isUsingVision, isAtCelling;

    

    private void FixedUpdate()
    {
        // Revient sur la Tete
        if (wantsToRest && (transform.position != RestPos.position))
        {
            isUsingVision = false;
            transform.position = Vector3.MoveTowards(transform.position, RestPos.position, .15f);
        } else if (wantsToRest && transform.position == RestPos.position) // Quand est sur la tete, arrete de vouloir etre sur la tete
        {
            isAtCelling = false;
            wantsToRest = false;
            animCrow.SetBool("isFlying", false);
        }

        // Va au plafond
        if (!isAtCelling && isUsingVision && transform.position != centerCelling.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerCelling.position, .15f);
            animCrow.SetBool("isFlying", true);
        } else if (isUsingVision && transform.position == centerCelling.position) // Quand est au plafond, arrete de vouloir allez au plafond
        {
            isAtCelling = true;
            transform.SetParent(null);
        }
    }

    public void Rest()
    {
        if(transform.position != RestPos.position)
        {
            transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            wantsToRest = true;
        }
    }
}
