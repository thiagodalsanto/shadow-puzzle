using UnityEngine;

public class LightControll : MonoBehaviour
{
    public Transform[] movePositions;
    public KeyCode moveKey = KeyCode.Space;
    private int currentPositionIndex = 0;

    void Start()
    {
        // Definir a posição inicial do objeto na primeira posição do array de pontos de movimentação
        transform.position = movePositions[currentPositionIndex].position;
    }

    void Update()
    {
        // Verificar se a tecla de movimentação foi pressionada
        if (Input.GetKeyDown(moveKey))
        {
            // Incrementar o índice da posição atual e se for maior que o tamanho do array, reiniciar para zero
            currentPositionIndex++;
            if (currentPositionIndex >= movePositions.Length)
            {
                currentPositionIndex = 0;
            }

            // Teleportar o objeto para a próxima posição de movimentação
            transform.position = movePositions[currentPositionIndex].position;
        }
    }
}