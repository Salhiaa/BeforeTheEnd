using UnityEngine;

public class Jardinier : MonoBehaviour
{
    public Sprite[] etatJardinier;
    [SerializeField] string[] firstInteraction;
    [SerializeField] string[] whenFreed;
    [SerializeField] Monologue speechBox;

    uint linesIndex = 0;
    bool playerCanInteract;
    bool freed = false;

    GameObject GM;
    GameObject CrowsEye;

    private void Start() {
        GM=GameObject.Find("GameManager");
        if (GM.GetComponent<GameManager>().usedKeyCage) GetComponent<SpriteRenderer>().sprite = etatJardinier[1];
    }

    private void Update()
    {
        if (playerCanInteract && Input.GetKeyDown(KeyCode.E))
        {
            //Si le joueur donne la clef
            if (GM.GetComponent<GameManager>().item == "KeyCage") 
            {
                GM.GetComponent<GameManager>().UseKeyCage();
                speechBox.Say(whenFreed[0], false);
                gameObject.GetComponent<SpriteRenderer>().sprite = etatJardinier[1];
                linesIndex++;
                freed = true;
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
                    CrowsEye=GameObject.Find("CrowsEye");
                    CrowsEye.SetActive(true);
                    GM.GetComponent<GameManager>().canUseVision = true;
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
                    if(!GM.GetComponent<GameManager>().gotBottle){
                        GM.GetComponent<GameManager>().PickBottle();
                    }
                }
                linesIndex++;
            }
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
}
