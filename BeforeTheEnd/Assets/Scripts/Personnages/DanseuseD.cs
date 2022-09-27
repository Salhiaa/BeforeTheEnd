using UnityEngine;

public class DanseuseD : Character
{
    [Header("Speech components")]
    [SerializeField] Dialogue dial;

    [Header("First Interaction")]
    [SerializeField] string BeforeAwakening;

    [Header("When Awakened")]
    [SerializeField] Sprite awakened;
    [SerializeField] string[] Awakening;
    bool isAwake;

    void Awake()
    {
        if (GameManager.Instance.dancerAwakened == true)
            WakeUp();
    }

    //---gestion du dialogue---
    public override void Interact()
    {
        if (!GameManager.Instance.dancersSpeechOver)
        {
            // --- Monologue : After awakening --- //
            if (isAwake)
            {
                if (linesIndex <= Awakening.Length - 1)
                {
                    dial.Say(Awakening[linesIndex]);
                }
                else if (linesIndex == Awakening.Length) //fin de l'interaction
                {
                    //hide speechbox
                    speechBox.Say("", true);
                    //show power indication
                    PowerIndication.SetActive(true);
                    //grant power
                    GameManager.Instance.canFetchObject = true;
                }
                else //hide power indication
                {
                    PowerIndication.SetActive(false);
                    GameManager.Instance.dancersSpeechOver = true;
                    EndDialogue();
                }
            }
            // --- Monologue : First Interaction --- //
            else
            {
                if (linesIndex == 0)
                {
                    speechBox.Say(BeforeAwakening, false);
                } else
                {
                    speechBox.Say("", true);
                    EndDialogue();
                }
            }

            base.Interact();
        }
    }

    public void WakeUp()
    {
        linesIndex = 0;
        GetComponent<SpriteRenderer>().sprite = awakened;
        isAwake = true;
    }
}
