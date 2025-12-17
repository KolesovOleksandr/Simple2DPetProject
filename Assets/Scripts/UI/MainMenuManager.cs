using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject settings;

    private void OpenCloseSettings()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        settings.SetActive(!settings.activeSelf);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        OpenCloseSettings();
    }

    public void AcceptSettings()
    {
        OpenCloseSettings();
    }


    public void QuitGame()
    {
        // This is ignored in the Unity Editor
        Application.Quit();
    }
}
