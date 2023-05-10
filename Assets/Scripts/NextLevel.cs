using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelWinning();
        }
    }

    private void LevelWinning()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}