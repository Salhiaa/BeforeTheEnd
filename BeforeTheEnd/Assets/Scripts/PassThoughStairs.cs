using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThoughStairs : MonoBehaviour
{
    [SerializeField] EdgeCollider2D edgeCol;
    [SerializeField] CorbeauMovement lePiaf;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lePiaf.wantsToRest = false;
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<EdgeCollider2D>().enabled = false;
            }
            edgeCol.enabled = false;
        }
    }
}
