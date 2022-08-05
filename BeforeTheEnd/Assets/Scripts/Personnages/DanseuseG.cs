using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseuseG : Interactable
{
    public Sprite move;
    [SerializeField] SpriteRenderer srDanseuse;

    [SerializeField] string[] firstInteraction;
    [SerializeField] Monologue speechBox;

    public GameObject[] appearAfterSpeech;

    uint linesIndex;

    private void Awake()
    {
        if (GameManager.Instance.talkedToWaitress && !GameManager.Instance.gotHeart)
        {
            Show();
        }
    }

    public override void Interact()
    {
        //Premiere interaction
        if (linesIndex <= firstInteraction.Length - 1)
        {
            speechBox.Say(firstInteraction[linesIndex], false);
        }
        else //fin de l'interaction
        {
            Show();
            GetComponent<Transform>().position = new Vector3(-3.04f, -0.02f, -2f);
            speechBox.Say(firstInteraction[0], true);
            GameManager.Instance.talkedToWaitress = true;
        }
        linesIndex++;
    }

    private void Show()
    {
        foreach (GameObject element in appearAfterSpeech)
        {
            element.SetActive(true);
        }
        GetComponent<SpriteRenderer>().sprite = move;
        GetComponent<Transform>().position = new Vector3(-3.04f, -0.02f, -2f);
    }
}
