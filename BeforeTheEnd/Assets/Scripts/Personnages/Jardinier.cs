using UnityEngine;

public class Jardinier : Interactable
{
    
    [SerializeField] string[] firstInteraction;
    [SerializeField] string[] whenFreed;
    [SerializeField] Monologue speechBox;
    public uint linesIndex = 0;
    
    public Sprite itemSprite;

    public Sprite GardenerFreed;
    public bool freed = false;

    public GameObject CrowsEye;

    private void Awake()
    {
        if (GameManager.Instance.usedKeyCage)
            GetComponent<SpriteRenderer>().sprite = GardenerFreed;
    }

    public override void Interact()
    {
        //Si le joueur donne la clef
        if (GameManager.Instance.item == "KeyCage")
        {
            GameManager.Instance.UseItem("KeyCage");
            GameManager.Instance.usedKeyCage = true;
            speechBox.Say(whenFreed[0], false);
            gameObject.GetComponent<SpriteRenderer>().sprite = GardenerFreed;
            freed = true;
            linesIndex++;
        }
        //Apres que le joueur ait donne la clef
        else if (freed)
        {
            if (linesIndex <= whenFreed.Length - 1)
            {
                speechBox.Say(whenFreed[linesIndex], false);
            }

            else if (linesIndex == whenFreed.Length) //fin du texte
            {
                speechBox.Say(whenFreed[0], true);
                CrowsEye.SetActive(true);
                GameManager.Instance.canUseVision = true;
            }
            else //apres la fin du texte
            {
                CrowsEye.SetActive(false);
            }
            linesIndex++;
        }
        //Sinon, premiere interaction
        else
        {
            if (linesIndex <= firstInteraction.Length - 1)
            {
                speechBox.Say(firstInteraction[linesIndex], false);
            }
            else //fin du texte
            {
                speechBox.Say(firstInteraction[0], true);
                if (!GameManager.Instance.gotBottle)
                {
                    GameManager.Instance.PickItem("EmptyBottle", itemSprite);
                    GameManager.Instance.gotBottle = true;
                }
            }
            linesIndex++;
        }
    }
}
