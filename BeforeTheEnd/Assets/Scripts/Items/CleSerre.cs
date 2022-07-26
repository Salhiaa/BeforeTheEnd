using UnityEngine;

public class CleSerre : Interactable
{
    public Sprite itemSprite;

    private void Awake()
    {
        if (GameManager.Instance.gotKeyCage)
            Destroy(gameObject);
    }

    public override void Interact()
    {
        GameManager.Instance.PickItem("KeyCage", itemSprite);
        GameManager.Instance.gotKeyCage = true;
        Destroy(gameObject);
    }
}
