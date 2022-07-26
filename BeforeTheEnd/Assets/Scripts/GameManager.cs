using UnityEngine;

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

    // Overlay
    [Header("Overlay")]
    public SpriteRenderer ItemIcon;
    public SpriteRenderer ItemIcon2;
    public GameObject Darkness;
    public string item = "";
    public string item2 = "";

    // Spawn Point
    [Header("Player spawn point")]
    public Vector3 spawnPoint = new Vector3(-8, -3.2f, 0);

    // Pouvoirs disponibles
    [Header("Crow Powers")]
    public bool canUseVision;
    public bool canFetchObject;
    public bool canTalk;

    // Variables de niveau
    [Header("Level : Entry")]
    public bool alreadyVisitedEntree;
    public bool torchPickedUp;

    [Header("Level : Greenhouse")]
    public bool gotBottle;
    public bool gotSeeds;
    public bool usedSeeds;
    public bool plantGrew;
    public bool gotKeyCage;
    public bool usedKeyCage;
    //public bool gardenerSpeechOver;

    [Header("Level : Dance Hall")]
    public bool talkedToWaitress;
    public bool gotHeart;
    public bool dancerAwakened;
    public bool dancersSpeechOver;

    [Header("Level : Music Room")]
    public bool gotLadderDown;

    [Header("Level : Shore")]
    public bool gotShoreKey;
    public bool gotBridgeKey;


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
