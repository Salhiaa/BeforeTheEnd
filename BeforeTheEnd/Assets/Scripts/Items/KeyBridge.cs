using UnityEngine;

public class KeyBridge : Interactable
{
    public Sprite itemSprite;

    private void Awake()
    {
        if (GameManager.Instance.gotShoreKey)
            Destroy(gameObject);
    }

    public override void Interact()
    {
        GameManager.Instance.PickItem("ShoreKey", itemSprite);
        GameManager.Instance.gotShoreKey = true;
        Destroy(gameObject);
    }
}
