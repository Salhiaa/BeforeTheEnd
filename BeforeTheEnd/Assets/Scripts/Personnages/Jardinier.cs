using UnityEngine;

public class Jardinier : Character
{

    [Header("First interaction")]
    [SerializeField] string[] firstInteraction;
    public Sprite itemSprite;

    [Header("When key given")]
    [SerializeField] string[] whenFreed;
    public Sprite GardenerFreed;
    public bool freed = false;

    private void Awake()
    {
        if (GameManager.Instance.usedKeyCage)
            GetComponent<SpriteRenderer>().sprite = GardenerFreed;
    }

    public override void Interact()
    {
        // --- Monologue : When key given --- //
        // Beginning of interaction
        if (GameManager.Instance.item == "KeyCage")
        {
            GameManager.Instance.UseItem("KeyCage");
            GameManager.Instance.usedKeyCage = true;
            speechBox.Say(whenFreed[0], false);
            gameObject.GetComponent<SpriteRenderer>().sprite = GardenerFreed;
            freed = true;
            base.Interact();
        } 
        // During interaction
        else if (freed)
        {
            if (linesIndex <= whenFreed.Length - 1)
            {
                speechBox.Say(whenFreed[linesIndex], false);
            }

            // When dialogue over
            else if (linesIndex == whenFreed.Length) 
            {
                speechBox.Say(whenFreed[0], true); // Hide textbox
                PowerIndication.SetActive(true);
                GameManager.Instance.canUseVision = true; // Grant power
            }
            // End interaction
            else
            {
                PowerIndication.SetActive(false); // Hide power indication
                EndDialogue(); // Give Movement back to player
            }
            base.Interact();
        }

        // --- Monologue : First Interaction --- //
        else if (!GameManager.Instance.gotBottle)
        {
            // During interaction
            if (linesIndex <= firstInteraction.Length - 1)
            {
                speechBox.Say(firstInteraction[linesIndex], false);
            }
            // End interaction
            else
            {
                EndDialogue(); // Give Movement back to player
                speechBox.Say(firstInteraction[0], true); // Hide textbox
                // Give bottle
                if (!GameManager.Instance.gotBottle)
                {
                    GameManager.Instance.PickItem("EmptyBottle", itemSprite);
                    GameManager.Instance.gotBottle = true;
                }
            }
            base.Interact();
        }
    }
}
