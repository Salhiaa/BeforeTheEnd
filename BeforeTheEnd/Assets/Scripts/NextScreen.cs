using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] Vector3 goTo;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("interact");
            GameManager.instance.setSpawnPoint(goTo);
            SceneManager.LoadScene(scene);
        }
    }
}