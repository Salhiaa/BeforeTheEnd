using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThoughFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<EdgeCollider2D>().enabled = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<EdgeCollider2D>().enabled = false;
            }
        }
    }
}
