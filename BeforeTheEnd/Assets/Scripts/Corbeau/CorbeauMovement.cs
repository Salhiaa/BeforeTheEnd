using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CorbeauMovement : MonoBehaviour
{
    [SerializeField] Transform RestPos;

    [SerializeField] Animator animCrow;
    [SerializeField] SpriteRenderer srOizo;

    public PlayerMovement PlayerMvt;

    public bool wantsToRest;
    public bool isUsingVision, isAtCelling;
    Vector3 visionPoint;

    private Transform selfTransform;
    private Transform playerTransform;

    private void Awake()
    {
        visionPoint = new Vector3 (0, 4.92f, 0);
        selfTransform = transform;
        playerTransform = PlayerMvt.transform;
    }

    private void FixedUpdate()
    {
        // Revient sur la Tete
        if (wantsToRest)
        {
            if (selfTransform.position == RestPos.position) // Quand est sur la tete, arrete de vouloir etre sur la tete
            {
                isAtCelling = false;
                wantsToRest = false;
                animCrow.SetBool("isFlying", false);
                PlayerMvt.switchAnimationLayer(true);
            }
            else
            {
                isUsingVision = false;
                selfTransform.position = Vector3.MoveTowards(selfTransform.position, RestPos.position, .15f);
                FlipXIf(RestPos.position.x);
            }
        }

        // Va au plafond
        if (isUsingVision & !isAtCelling)
        {
            if (selfTransform.position == visionPoint) // Quand est au plafond, arrete de vouloir allez au plafond
            {
                isAtCelling = true;
                selfTransform.SetParent(null);
            } else
            {
                selfTransform.position = Vector3.MoveTowards(selfTransform.position, visionPoint, .15f);
                animCrow.SetBool("isFlying", true);
                PlayerMvt.switchAnimationLayer(false);
                FlipXIf(visionPoint.x);
            }
        }

        // Va chercher un objet

    }

    public void Rest()
    {
        if(selfTransform.position != RestPos.position)
        {
            selfTransform.SetParent(playerTransform);
            wantsToRest = true;
        }
    }

    //Check if sprite needs to flip
    public void FlipXIf(float targetx)
    {
        if (targetx < selfTransform.position.x)
        {
            srOizo.flipX = false;
        }
        else if (targetx > selfTransform.position.x)
        {
            srOizo.flipX = true;
        }
        
    }
}
