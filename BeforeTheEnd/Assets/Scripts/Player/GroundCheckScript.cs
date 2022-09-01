using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundCheckScript : MonoBehaviour
{
    bool canPassThrough;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PassPlatform"))
        {
            collision.isTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canPassThrough && collision.CompareTag("PassPlatform"))
        {
            collision.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string collName = collision.name;
        if (collision.CompareTag("PassPlatform") && collName != "SolVisibleSallePortes")
        {
            collision.isTrigger = true;
        }
    }

    public void PassThroughFloor(InputAction.CallbackContext context)
    {
        canPassThrough = context.control.IsPressed();
    }
}
