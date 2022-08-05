using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionHandler : MonoBehaviour
{
    public bool canInteract = false;
    private Collider2D coll;

    public void Interact(InputAction.CallbackContext context)
    {
        //print(coll.name);
        if (context.started && canInteract)
        {
            coll.GetComponent<Interactable>().Interact();
            //print("interact");
        }
    }

    /* In some cases, OnTriggerEnter didn't want to worlk, so I ended up
     using OnTriggerStay even if it's not the best...
     * Details : In the dance hall (and maybe elsewhere) OnTriggerExit 
     fires when in collision with heart location - or it fires on exit and 
     OnTriggerEnter doesn't fire back
     * Suspected : Interference with Dancer collider*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canInteract && collision.CompareTag("Interactable"))
        {
            coll = collision;
            canInteract = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            canInteract = false;
        }
    }
}
