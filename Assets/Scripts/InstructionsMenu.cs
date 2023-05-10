using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionsMenu : MonoBehaviour
{
    public Button goBackToMainMenu;

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
