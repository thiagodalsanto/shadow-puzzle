using UnityEngine;
using UnityEngine.UI;

public class ShadowButtons : MonoBehaviour
{
    public GameObject objectToMove;
    public Transform[] movePositions;
   

    private bool isLookingAtObject = false;
    private int currentPositionIndex = 0;
    public AudioSource buttonPress;

    private void Start()
    {
        // Define a posição inicial do objeto na primeira posição da lista
        objectToMove.transform.position = movePositions[currentPositionIndex].position;
        objectToMove.transform.rotation = movePositions[currentPositionIndex].rotation;
    }

    private void Update()
    {
        // Verifica se o jogador está olhando para o objeto e pressionou a tecla "E"
        if (isLookingAtObject && Input.GetKeyDown(KeyCode.E))
        {
            // Move o objeto para o próximo local da lista de movimentação
            
            currentPositionIndex++;
            if (currentPositionIndex >= movePositions.Length)
            {
                currentPositionIndex = 0;
            }
            objectToMove.transform.position = movePositions[currentPositionIndex].position;
            objectToMove.transform.rotation = movePositions[currentPositionIndex].rotation;

            buttonPress.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou na área do objeto
        if (other.gameObject.CompareTag("Player"))
        {
            isLookingAtObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o jogador saiu da área do objeto
        if (other.gameObject.CompareTag("Player"))
        {
            isLookingAtObject = false;
        }
    }
}
