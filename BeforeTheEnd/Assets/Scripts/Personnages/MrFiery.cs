using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrFiery : Character
{
    [Header("Dialogues")]
    [SerializeField] string[] firstInteraction;
    [SerializeField] string fear;
    [SerializeField] string[] otherSide;

    public override void Interact()
    {
        // --- Monologue : First Interaction --- //
        if (linesIndex <= firstInteraction.Length - 1)
        {
            speechBox.Say(firstInteraction[linesIndex], false);
        }
        // End interaction
        else
        {
            EndDialogue(); // Give Movement back to player
            speechBox.Say(firstInteraction[0], true); // Hide textbox
        }
        base.Interact();
    }
}
