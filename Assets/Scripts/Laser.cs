using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 1.0f;
    public float transitionTime = 1.0f;

    private float t = 0.0f;
    private bool movingTo2 = true;

    private void Update()
    {
        if (movingTo2)
        {
            t += Time.deltaTime / transitionTime;
            transform.position = Vector3.Lerp(point1.position, point2.position, t * speed);
            if (t >= 1.0f)
            {
                movingTo2 = false;
                t = 0.0f;
            }
        }
        else
        {
            t += Time.deltaTime / transitionTime;
            transform.position = Vector3.Lerp(point2.position, point1.position, t * speed);
            if (t >= 1.0f)
            {
                movingTo2 = true;
                t = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
