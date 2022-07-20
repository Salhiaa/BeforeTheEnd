using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PassPlatform"))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PassPlatform") && Input.GetKey(KeyCode.S))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PassPlatform"))
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
