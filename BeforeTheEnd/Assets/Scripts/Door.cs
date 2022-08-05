using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [SerializeField] string scene;
    public  bool isLocked = false;
    [SerializeField] Vector3 goTo;

    public override void Interact()
    {
        if (!isLocked)
        {
            GameObject.Find("Player").GetComponent<SFXManager>().PlayOuverturePorte();
            Debug.Log("interact");
            GameManager.Instance.setSpawnPoint(goTo);
            SceneManager.LoadScene(scene);
        }
    }
}
