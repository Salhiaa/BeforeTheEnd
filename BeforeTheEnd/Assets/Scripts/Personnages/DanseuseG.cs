using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseuseG : MonoBehaviour
{
    public Sprite[] etatDanseuseG;
    [SerializeField] SpriteRenderer srDanseuse;

    [SerializeField] string[] firstInteraction;
    [SerializeField] Monologue speechBox;

    public GameObject[] appearAfterSpeech;

    uint linesIndex;
    bool playerCanInteract;

    private void Update()
    {
        if (playerCanInteract && Input.GetKeyDown(KeyCode.E))
        {
            //Premiere interaction
            if (linesIndex <= firstInteraction.Length - 1)
            {
                speechBox.Say(firstInteraction[linesIndex], false);
            }
            else //fin de l'interaction
            {
                srDanseuse.sprite = etatDanseuseG[1];
                Toggle();
                GetComponent<Transform>().position = new Vector3(-3.04f,-0.02f,-2f);
                speechBox.Say(firstInteraction[0], true);
                Destroy(this);
            }
            linesIndex++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCanInteract = false;
            speechBox.Say("", true);
            linesIndex = 0;
        }
    }

    private void Toggle(){
        foreach (GameObject element in appearAfterSpeech)
            {
                element.SetActive(true);
            }
    }
}
