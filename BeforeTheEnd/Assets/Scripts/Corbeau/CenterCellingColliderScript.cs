using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCellingColliderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Raven"))
        {
            collision.GetComponent<CorbeauMovement>().wantsToRest = true;
        }
    }
}
