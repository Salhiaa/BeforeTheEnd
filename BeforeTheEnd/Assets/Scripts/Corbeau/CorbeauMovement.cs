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

    [SerializeField] GameObject Player;
    public PlayerMovement PlayerMvt;

    public bool wantsToRest = false;
    public bool isUsingVision, isAtCelling;
    Vector3 highPoint;

    private void Awake()
    {
        PlayerMvt = Player.GetComponent<PlayerMovement>();
        highPoint = centerCelling.position;
    }


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
            PlayerMvt.crowRested = true;
        }

        // Va au plafond
        if (isUsingVision)
        {
            if (transform.position == highPoint) // Quand est au plafond, arrete de vouloir allez au plafond
            {
                isAtCelling = true;
                transform.SetParent(null);
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, highPoint, .15f);
                animCrow.SetBool("isFlying", true);
                PlayerMvt.crowRested = false;
                if (RestPos.position.x > highPoint.x)
                {
                    srOizo.flipX = false;
                } else
                {
                    srOizo.flipX = true;
                }
            }
            
        }
    }

    public void Rest()
    {
        if(transform.position != RestPos.position)
        {
            transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            wantsToRest = true;

            if (RestPos.position.x > highPoint.x)
            {
                srOizo.flipX = true;
            }
            else
            {
                srOizo.flipX = false;
            }
        }
    }
}
