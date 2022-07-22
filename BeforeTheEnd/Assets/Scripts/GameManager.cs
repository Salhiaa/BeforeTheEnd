using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Vector3 spawnPoint = new Vector3(-8,-3.2f,0);

    public Sprite BtnInteraction;
    public Sprite BtnInventaire;
    public Sprite Square;
    private GameObject itemUI;
    private GameObject ItemIcon;
    private GameObject ItemIcon2;
    public string item="";
    public string item2="";

    //Pouvoirs disponibles
    public bool canUseVision, canSearchObject, canTalk;

    //Gestion de la lumiere dans l'entree
    public Sprite torchSprite;
    private GameObject Darkness;
    public bool appliedDarkness = false;
    public bool alreadyVisitedEntree = false;
    public bool torchPickedUp = false;
    public bool fireplaceLit = false;

    // Variables pour les items de la serre
    public Sprite EmptyBottle;
    public Sprite FullBottle;
    public Sprite Seeds;
    public Sprite KeyCage;
    public bool gotBottle=false;
    public bool gotSeeds=false;
    public bool usedSeeds=false;
    public bool usedWater=false;
    public bool usedKeyCage = false;

    //Gestion de la plante (Serre)
    public bool plantGrew=false;
    //public GameObject Bourgeon;
    public GameObject TroncPlante;

    //Variables pour la salle de de danse
    public Sprite Heart;
    public bool gotHeart = false;
    public bool dancerAwakened;


    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Destroy(itemUI);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
            itemUI = new GameObject("ItemUI",typeof(SpriteRenderer));
            itemUI.GetComponent<Transform>().position = new Vector3(8,4,0);
            itemUI.GetComponent<Transform>().localScale = new Vector3(1.2f,1.2f,1.2f);
            itemUI.GetComponent<SpriteRenderer>().sortingOrder = 10;
            itemUI.GetComponent<SpriteRenderer>().sprite = BtnInventaire;
            DontDestroyOnLoad(itemUI);
        }
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name == "Entree" || SceneManager.GetActiveScene().name == "DoorRoom")
        {
            if (!alreadyVisitedEntree){
                alreadyVisitedEntree = true;
            }

            if (GameObject.Find("Darkness") == null){
                appliedDarkness=false;
            } else appliedDarkness=true;

            if (!fireplaceLit && !appliedDarkness) {
                ApplyDarkness();
            }
        }

        if(GameObject.Find("ItemFinder")!=null){
            //Bourgeon = GameObject.Find("ItemFinder").GetComponent<ItemFinder>().Bourgeon;
            TroncPlante = GameObject.Find("ItemFinder").GetComponent<ItemFinder>().TroncPlante;
        }
    }
    
    public void setSpawnPoint(Vector3 spawn)
    {
        spawnPoint = spawn;
    }
    public Vector3 getSpawnPoint()
    {
        return spawnPoint;
    }

    //Gestion de la lumiere dans l'entree
    private void ApplyDarkness(){
        Darkness = new GameObject("Darkness",typeof(SpriteRenderer));
        Darkness.GetComponent<Transform>().position = new Vector3(0,0,0);
        Darkness.GetComponent<Transform>().localScale = new Vector3(50,50,0);
        Darkness.GetComponent<SpriteRenderer>().sortingOrder = 9;
        Darkness.GetComponent<SpriteRenderer>().sprite = Square;
        Darkness.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.9f);
    }

    public void LightFireplace(){
        //ResetUI();
        Destroy(ItemIcon);
        Destroy(Darkness);
        item="";
        fireplaceLit = true;
        GameObject.Find("DoorManager").GetComponent<DoorsEntree>().Lit();
    }


    //Faire grandir la plante de la serre
    public void GrowPlant()
    {
        Destroy(ItemIcon);
        Destroy(ItemIcon2);
        item = "";
        item2 = "";
        plantGrew = true;
        TroncPlante.SetActive(true);
    }

    //Reveiller la danseuse
    public void AwakenDancer()
    {
        Destroy(ItemIcon);
        item = "";
        dancerAwakened = true;
        //print("ARISE !");
    }


    //---------------------------------------------Gestion de l'UI et de l'inventaire---------------------------------------------

    //-----Jardin-----
    //Torche
    public void PickTorch(){
        item="torche";
        torchPickedUp=true;
        itemUI.GetComponent<SpriteRenderer>().sprite = BtnInventaire;
        ItemIcon = new GameObject("ItemIcon",typeof(SpriteRenderer));
        itemUI.GetComponent<Transform>().localScale = new Vector3(1.2f,1.2f,0);
        ItemIcon.GetComponent<Transform>().position = new Vector3(8,4,0);
        ItemIcon.GetComponent<Transform>().localScale = new Vector3(.7f,.7f,0);
        ItemIcon.GetComponent<SpriteRenderer>().sortingOrder = 10;
        ItemIcon.GetComponent<SpriteRenderer>().sprite = torchSprite;
        DontDestroyOnLoad(ItemIcon);
    }

    //-----Serre-----
    //Bouteille
    public void PickBottle(){
        item2="EmptyBottle";
        ItemIcon2 = new GameObject("ItemIcon2",typeof(SpriteRenderer));
        ItemIcon2.GetComponent<Transform>().position = new Vector3(8.25f,3.85f,0);
        ItemIcon2.GetComponent<Transform>().localScale = new Vector3(.16f,.16f,0);
        ItemIcon2.GetComponent<SpriteRenderer>().sortingOrder = 10;
        ItemIcon2.GetComponent<SpriteRenderer>().sprite = EmptyBottle;
        DontDestroyOnLoad(ItemIcon2);
    }

    public void FillBottle(){
        item2="FullBottle";
        ItemIcon2.GetComponent<SpriteRenderer>().sprite = FullBottle;
        DontDestroyOnLoad(ItemIcon);
    }

    //Graines
    public void pickSeeds(){
        item="Seeds";
        gotSeeds=true;
        ItemIcon = new GameObject("ItemIcon",typeof(SpriteRenderer));
        ItemIcon.GetComponent<Transform>().position = new Vector3(7.75f, 4, 0);
        ItemIcon.GetComponent<Transform>().localScale = new Vector3(.4f,.4f, 0);
        ItemIcon.GetComponent<SpriteRenderer>().sortingOrder = 10;
        ItemIcon.GetComponent<SpriteRenderer>().sprite = Seeds;
        DontDestroyOnLoad(ItemIcon);
    }

    //Cle Serre
    public void pickKeyCage()    {
        item = "KeyCage";
        gotSeeds = true;
        ItemIcon = new GameObject("ItemIcon", typeof(SpriteRenderer));
        ItemIcon.GetComponent<Transform>().position = new Vector3(7.95f, 4, 0);
        ItemIcon.GetComponent<Transform>().localScale = new Vector3(2.5f, 2.5f, 0);
        ItemIcon.GetComponent<SpriteRenderer>().sortingOrder = 10;
        ItemIcon.GetComponent<SpriteRenderer>().sprite = KeyCage;
        DontDestroyOnLoad(ItemIcon);
    }

    public void UseKeyCage()
    {
        Destroy(ItemIcon);
        item = "";
        usedKeyCage = true;
    }

    //-----Salle de danse-----
    public void pickHeart()
    {
        item = "Heart";
        gotHeart = true;
        ItemIcon = new GameObject("ItemIcon", typeof(SpriteRenderer));
        ItemIcon.GetComponent<Transform>().position = new Vector3(8.1f, 3.9f, 0);
        ItemIcon.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0);
        ItemIcon.GetComponent<SpriteRenderer>().sortingOrder = 10;
        ItemIcon.GetComponent<SpriteRenderer>().sprite = Heart;
        DontDestroyOnLoad(ItemIcon);
    }
}
