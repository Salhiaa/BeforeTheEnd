using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCheckState : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponentInParent<EdgeCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<EdgeCollider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<EdgeCollider2D>().enabled = true;
        }
    }
}
