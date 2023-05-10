using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLooping : MonoBehaviour
{
    private int currentSceneIndex;

    void Awake()
    {
        GameObject musicObj = GameObject.FindGameObjectWithTag("GameAudio");
        if (musicObj != null && musicObj != this.gameObject)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        // Registra o método OnSceneLoaded como listener para o evento SceneManager.sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Atualiza o índice da cena atual
        currentSceneIndex = scene.buildIndex;

        // Verifica se o índice da cena está dentro do intervalo desejado
        if (currentSceneIndex >= 1 && currentSceneIndex <= 4)
        {
            // Toca a música em looping
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
        }
        else
        {
            // Para a música
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Stop();
        }
    }

    void OnDestroy()
    {
        // Remove o método OnSceneLoaded como listener para o evento SceneManager.sceneLoaded
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
