using UnityEngine;

public class Inertia : MonoBehaviour
{
    public Transform[] movePositions;
    public float speed = 5f;
    public bool loop = true;
    private bool start = false;

    private int currentPositionIndex = 0;
    private Vector3 lastPlayerPosition;

    private void Start()
    {
        // Definir a posição inicial do objeto na primeira posição do array de pontos de movimentação
        transform.position = movePositions[currentPositionIndex].position;
    }

    private void FixedUpdate()
    {
        if(start){    
            // Calcular a direção e a distância para a próxima posição
            Vector3 direction = movePositions[currentPositionIndex].position - transform.position;
            float distanceToTarget = direction.magnitude;

            // Verificar se o objeto ainda não chegou na posição desejada
            if (distanceToTarget > 0.1f)
            {
                // Normalizar a direção e aplicar a velocidade para mover o objeto
                direction.Normalize();
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                // O objeto chegou na posição desejada, atualizar a posição atual
                 currentPositionIndex++;
                if (currentPositionIndex >= movePositions.Length)
                {
                    if (loop)
                    {
                        currentPositionIndex = 0;
                    }
                    else
                    {
                        // Parar a plataforma
                        enabled = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
        start = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
