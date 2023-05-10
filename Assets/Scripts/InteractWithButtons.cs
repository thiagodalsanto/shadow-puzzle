using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractWithButtons : MonoBehaviour
{    
    private bool isPlayerNear = false; // Controla se o jogador está olhando para o objeto
    public TMP_Text interactText;
    [HideInInspector] public Senha senha;

    void Start()
    {
        interactText.enabled = false;
        senha = GameObject.FindObjectOfType<Senha>();
    }

    void Update()
    {
        // Verifica se o objeto atingido é interativo
        if (isPlayerNear == true)
        {
            // Habilita o objeto Text de UI
            interactText.enabled = true;

            if (senha.passwordUI.activeSelf)
            {
                interactText.enabled = false;
            }
        }
        else
        {
            interactText.enabled = false;
        }

        if (senha.passwordUI.activeSelf)
        {
            interactText.enabled = false;
        }

        if(interactText.enabled == true && isPlayerNear == true && Input.GetKeyDown(KeyCode.Escape))
        {
            interactText.enabled = false;
        }

        if(interactText.enabled == true && isPlayerNear == false && Input.GetKeyDown(KeyCode.Escape))
        {
            interactText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou na área do objeto
        if (other.CompareTag("Player"))
        {
            // O jogador está perto do objeto
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
