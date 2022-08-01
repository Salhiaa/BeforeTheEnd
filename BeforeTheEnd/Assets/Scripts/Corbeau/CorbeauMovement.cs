using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CorbeauMovement : MonoBehaviour
{
    [SerializeField] Transform RestPos;
    [SerializeField] Transform centerCelling;

    [SerializeField] Animator animCrow;
    [SerializeField] SpriteRenderer srOizo;

    public PlayerMovement PlayerMvt;

    public bool wantsToRest;
    public bool isUsingVision, isAtCelling;
    Vector3 visionPoint;

    private void Awake()
    {
        visionPoint = centerCelling.position;
    }

    private void FixedUpdate()
    {
        // Revient sur la Tete
        if (wantsToRest)
        {
            if (transform.position == RestPos.position) // Quand est sur la tete, arrete de vouloir etre sur la tete
            {
                isAtCelling = false;
                wantsToRest = false;
                animCrow.SetBool("isFlying", false);
                PlayerMvt.switchAnimationLayer(true);
            }
            else
            {
                isUsingVision = false;
                transform.position = Vector3.MoveTowards(transform.position, RestPos.position, .15f);
                FlipXIf(RestPos.position.x);
            }
        }

        // Va au plafond
        if (isUsingVision)
        {
            if (transform.position == visionPoint) // Quand est au plafond, arrete de vouloir allez au plafond
            {
                isAtCelling = true;
                transform.SetParent(null);
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, visionPoint, .15f);
                animCrow.SetBool("isFlying", true);
                PlayerMvt.switchAnimationLayer(false);
                FlipXIf(visionPoint.x);
            }
            
        }
    }

    public void Rest()
    {
        if(transform.position != RestPos.position)
        {
            transform.SetParent(PlayerMvt.transform);
            wantsToRest = true;
        }
    }

    //Check if sprite needs to flip
    public void FlipXIf(float targetx)
    {
        if (targetx < transform.position.x)
        {
            srOizo.flipX = false;
        }
        else if (targetx > transform.position.x)
        {
            srOizo.flipX = true;
        }
        
    }
}
