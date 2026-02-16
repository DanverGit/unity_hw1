using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleData obstacleData; // —сылка на ScriptableObject

    private void Update()
    {
        if (obstacleData == null)
        {
            Debug.LogError("ObstacleData is not assigned.");
            return;
        }

        transform.Translate(Vector3.left * obstacleData.moveSpeed * Time.deltaTime);

        if (transform.position.x < obstacleData.destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    // ќбработка столкновений
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(obstacleData.damage);
            }

            Destroy(gameObject);
        }
    }
}
