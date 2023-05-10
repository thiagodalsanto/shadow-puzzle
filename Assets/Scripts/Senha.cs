using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Senha : MonoBehaviour
{
    public GameObject objectToDisappear; // Objeto que será removido quando a senha estiver correta
    public string correctPassword = "1234"; // Senha correta que fará o objeto desaparecer
    public GameObject passwordUI; // UI que exibe a tela para digitar a senha
    
    private bool isPlayerLooking = false; // Controla se o jogador está olhando para o objeto
    private bool isUIOpen = false; // Controla se a UI da senha está aberta

    public AudioSource buttonPress;

    private void Start(){
        passwordUI.SetActive(false);
        isUIOpen = false;
    }

    private void Update()
    {
        // Verifica se o jogador está olhando para o objeto e apertou "e"
        if (isPlayerLooking && Input.GetKeyDown(KeyCode.E))
        {   
            passwordUI.SetActive(true);
            isUIOpen = true;

            buttonPress.Play();

            // Seleciona o campo de input
            InputField inputField = passwordUI.GetComponentInChildren<InputField>();
            if (inputField != null)
            {
                inputField.gameObject.SetActive(true); // garante que o objeto esteja ativado
                inputField.Select();
            }
        }

    
        // Verifica se a UI da senha está aberta e o jogador apertou "enter"
        if (isUIOpen && Input.GetKeyDown(KeyCode.Return) )
        {   
            // Verifica se a senha digitada está correta
            string password = passwordUI.GetComponentInChildren<UnityEngine.UI.InputField>().text;
            
            if (password == correctPassword)
            {
                // Senha correta, remove o objeto
                Destroy(objectToDisappear);
            }

            // Fecha a UI da senha
            passwordUI.SetActive(false);
            isUIOpen = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Verifica se a UI da senha está aberta e o jogador apertou "enter"
        if (isUIOpen && Input.GetKeyDown(KeyCode.X) )
        {   
            // Fecha a UI da senha
            passwordUI.SetActive(false);
            isUIOpen = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(isUIOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            // Fecha a UI da senha
            passwordUI.SetActive(false);
            isUIOpen = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou na área do objeto
        if (other.CompareTag("Player"))
        {
            // O jogador está olhando para o objeto
            isPlayerLooking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o jogador saiu da área do objeto
        if (other.CompareTag("Player"))
        {
            // O jogador não está mais olhando para o objeto
            isPlayerLooking = false;
        }
    }
}
