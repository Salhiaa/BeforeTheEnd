using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] string scene;
    bool playerCanInteract = false;
    public  bool isLocked = false;
    [SerializeField] Vector3 goTo;

    public void Update()
    {
        if (playerCanInteract && !isLocked && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("Player").GetComponent<SFXManager>().PlayOuverturePorte();
            Debug.Log("interact");
            GameManager.instance.setSpawnPoint(goTo);
            SceneManager.LoadScene(scene);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCanInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCanInteract = false;
        }
    }
}
