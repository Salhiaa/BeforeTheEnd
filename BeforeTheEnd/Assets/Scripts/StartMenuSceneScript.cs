using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuSceneScript : MonoBehaviour
{
    [SerializeField] GameObject creditsPanels;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
    }

    public void sQuitGame()
    {
        Application.Quit();
    }

    public void ToogleCredit()
    {
        creditsPanels.SetActive(!creditsPanels.activeSelf);
    }
}
