using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseuseG : Character
{
    [Header("Sprite")]
    [SerializeField] Sprite move;
    [SerializeField] SpriteRenderer srDanseuse;

    [Header("Monologue")]
    [SerializeField] string[] firstInteraction;
    [SerializeField] GameObject[] appearAfterSpeech;

    private void Awake()
    {
        if (GameManager.Instance.talkedToWaitress)
            Show();
    }

    public override void Interact()
    {
        // --- Monologue : First Interaction --- //
        if (!GameManager.Instance.talkedToWaitress)
        {
            if (linesIndex <= firstInteraction.Length - 1)
            {
                speechBox.Say(firstInteraction[linesIndex], false);
            }
            // End of interaction
            else
            {
                Show();
                GetComponent<Transform>().position = new Vector3(-3.04f, -0.02f, -2f);
                speechBox.Say(firstInteraction[0], true);
                GameManager.Instance.talkedToWaitress = true;
                EndDialogue(); // Give Movement back to player
            }
            base.Interact();
        }
    }

    private void Show()
    {
        foreach (GameObject element in appearAfterSpeech)
        {
            element.SetActive(true);
        }
        srDanseuse.sprite = move;
        GetComponent<Transform>().position = new Vector3(-3.04f, -0.02f, -2f);
    }
}
