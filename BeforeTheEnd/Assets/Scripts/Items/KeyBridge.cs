using UnityEngine;

public class KeyBridge : Interactable
{
    public Sprite itemSprite;

    /*private void Awake()
    {
        if (GameManager.Instance.gotShoreKey)
            Destroy(gameObject);
    }*/

    public override void Interact()
    {
        print("hey");
        GameManager.Instance.PickItem("KeyBridge", itemSprite);
        GameManager.Instance.gotShoreKey = true;
        Destroy(gameObject);
    }
}
