using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrowPowers : MonoBehaviour
{
    public CorbeauMovement lePiaf;
    public GameObject toggleableObjects;
    public Camera mainCamera;

    //********* Vision *********//
    public void CrowVision(InputAction.CallbackContext context)
    {
        if (context.started && GameManager.Instance.canUseVision == true)
        {
            ToggleVision();
            GameObject.Find("Player").GetComponent<SFXManager>().PlayCrow1();
            GameObject.Find("Player").GetComponent<SFXManager>().PlayVision();
        }
    }

    private void ToggleVision()
    {
        if (lePiaf.isUsingVision)
        {
            lePiaf.Rest();
            toggleableObjects.SetActive(false);
        } else if (!lePiaf.wantsToRest)
        {
            lePiaf.isUsingVision = true;
            toggleableObjects.SetActive(true);
        }
    }

    //********* Fetch *********//
    public void CrowFetch(InputAction.CallbackContext context)
    {
        if (context.started && GameManager.Instance.canUseVision == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "CrowInteractable")
                {
                    print("Hey, ça marche !");
                }
            }
        }
    }

    //********* Speak *********//
    public void CrowSpeech(string s)
    {
        
    }
}