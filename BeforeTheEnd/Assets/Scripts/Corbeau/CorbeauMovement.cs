using UnityEngine;
using System.Threading.Tasks;

public class CorbeauMovement : MonoBehaviour
{
    [SerializeField] Transform RestPos;

    [SerializeField] Animator animCrow;
    [SerializeField] SpriteRenderer srOizo;

    public PlayerMovement PlayerMvt;

    public bool wantsToRest, isFlying, isUsingFetch, isAtDestination;
    public Vector3 targetLocation;
    public Interactable objectToFetch;

    private Transform selfTransform;
    private Transform playerTransform;

    private void Awake()
    {
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
                // Reset booleans
                isAtDestination = false;
                wantsToRest = false;
                animCrow.SetBool("isFlying", false);
                isFlying = false;
                if (isUsingFetch)
                {
                    isUsingFetch = false;
                    if (objectToFetch)
                    {
                        objectToFetch = null;
                    }
                }
                // Change player sprite for the one with the crow
                PlayerMvt.switchAnimationLayer(true);
            }
            else
            {
                selfTransform.position = Vector3.MoveTowards(selfTransform.position, RestPos.position, .12f);
                FlipXIf(RestPos.position.x);
            }
        }

        // Déplacement
        else if (isFlying & !isAtDestination)
        {
            if (selfTransform.position == targetLocation) // S'arrête quand atteint sa cible
            {
                isAtDestination = true;
                selfTransform.SetParent(null);
                if (isUsingFetch)
                {
                    StopFetch();
                }
                    
            } else
            {
                selfTransform.position = Vector3.MoveTowards(selfTransform.position, targetLocation, .12f);
                animCrow.SetBool("isFlying", true);
                PlayerMvt.switchAnimationLayer(false);
                FlipXIf(targetLocation.x);
            }
        }
    }

    async void StopFetch()
    {
        if (objectToFetch)
        {
            objectToFetch.Interact();
        }
        await Task.Delay(750);
        Rest();
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
