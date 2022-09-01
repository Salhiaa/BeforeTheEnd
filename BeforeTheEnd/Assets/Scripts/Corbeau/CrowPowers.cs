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
        if (context.started && GameManager.Instance.canUseVision)
        {
            ToggleVision();
            GameObject.Find("Player").GetComponent<SFXManager>().PlayCrow1();
            GameObject.Find("Player").GetComponent<SFXManager>().PlayVision();
        }
    }

    public void ToggleVision()
    {
        if (lePiaf.isFlying)
        {
            lePiaf.Rest();
            toggleableObjects.SetActive(false);
        } else if (!lePiaf.wantsToRest && !lePiaf.isFlying)
        {
            lePiaf.isFlying = true;
            lePiaf.targetLocation = new Vector3(0, 4.92f, 0);
            toggleableObjects.SetActive(true);
        }
    }

    //********* Fetch *********//
    public void CrowFetch(InputAction.CallbackContext context)
    {
        if (context.started && GameManager.Instance.canFetchObject)
        {
            if (!lePiaf.wantsToRest && !lePiaf.isFlying)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                lePiaf.isFlying = true;
                lePiaf.isUsingFetch = true;
                lePiaf.targetLocation = new Vector3(mousePos.x, mousePos.y, 0);

                // Collider test
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    GameObject coll = hit.collider.gameObject;
                    Debug.Log(coll.name);
                    if (coll.tag == "CrowInteractable")
                    {
                        print("Crow Interactable");
                        lePiaf.objectToFetch = coll.GetComponent<Interactable>();
                    }
                }
            }
        }
    }

    //********* Speak *********//
    public void CrowSpeech(string s)
    {
        
    }
}