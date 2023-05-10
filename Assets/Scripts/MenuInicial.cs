using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public Button playGameButton;
    public Button instructionsButton;
    public Button quitGameButton;
    public Button credits;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ShowInstructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }
}
