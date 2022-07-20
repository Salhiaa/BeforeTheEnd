using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionHandler : MonoBehaviour
{
    private bool canInteract = false;
    private GameObject[] everyInteractables;

    private void Awake()
    {
        everyInteractables = GameObject.FindGameObjectsWithTag("Interactable");
    }
}
