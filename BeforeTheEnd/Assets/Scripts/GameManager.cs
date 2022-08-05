using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            /*if (_instance is null)
                Debug.LogError("Game Manager is NULL");*/
            return _instance;
        }
    }

    public Vector3 spawnPoint = new Vector3(-8, -3.2f, 0);

    //UI
    public SpriteRenderer ItemIcon;
    public SpriteRenderer ItemIcon2;
    public GameObject Darkness;
    public string item = "";
    public string item2 = "";

    //Pouvoirs disponibles
    [Header("Crow Powers")]
    public bool canUseVision;
    public bool canSearchObject;
    public bool canTalk;

    //Gestion de la lumiere dans l'entree
    [Header("Level : Entry")]
    public bool alreadyVisitedEntree;
    public bool torchPickedUp;

    // Variables pour les items de la serre
    [Header("Level : Greenhouse")]
    public bool gotBottle;
    public bool gotSeeds;
    public bool usedSeeds;
    public bool plantGrew;
    public bool gotKey;
    public bool usedKeyCage;

    //Variables pour la salle de de danse
    [Header("Level : Dance Hall")]
    public bool talkedToWaitress;
    public bool gotHeart;
    public bool dancerAwakened;


    private void Awake()
    {
        if (!Instance)
        {
            _instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Spawn Player
    public void setSpawnPoint(Vector3 spawn)
    {
        spawnPoint = spawn;
    }


    // Gestion de l'UI et de l'inventaire
    public void PickItem(string name, Sprite sprite, string replaceItem = "")
    {
        if (item == "" || item == replaceItem) {
            item = name;
            ItemIcon.sprite = sprite;
        } else if (item2 == "" || item == replaceItem)
        {
            item2 = name;
            ItemIcon2.sprite = sprite;
        }
    }

    public void UseItem(string name)
    {
        if (item == name)
        {
            item = "";
            ItemIcon.sprite = default;
        }
        else if (item2 == name)
        {
            item2 = "";
            ItemIcon2.sprite = default;
        }
    }
}
