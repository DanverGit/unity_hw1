using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float topPosition = 10f;
    public float bottomPosition = -10f;

    public GameObject[] objectsToSpawn;
    public float initialMinSpawnInterval = 1f;
    public float initialMaxSpawnInterval = 3f;
    public float intervalDecreaseRate = 0.01f;

    private bool movingUp = true;
    private float timer = 0f;
    private float currentSpawnInterval;
    private float elapsedTime = 0f;

    void Start()
    {
        SetRandomSpawnInterval();
    }

    void Update()
    {
        MoveUpDown();

        elapsedTime += Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= currentSpawnInterval)
        {
            SpawnObject();
            timer = 0f;
            SetRandomSpawnInterval();
        }
    }

    // Метод для движения объекта вверх-вниз
    void MoveUpDown()
    {
        Vector3 currentPosition = transform.position;

        if (movingUp)
        {
            currentPosition.z += moveSpeed * Time.deltaTime;

            if (currentPosition.z >= topPosition)
            {
                currentPosition.z = topPosition;
                movingUp = false;
            }
        }
        else
        {
            currentPosition.z -= moveSpeed * Time.deltaTime;

            if (currentPosition.z <= bottomPosition)
            {
                currentPosition.z = bottomPosition;
                movingUp = true;
            }
        }

        transform.position = currentPosition;
    }

    // Метод для создания объектов
    void SpawnObject()
    {
        if (objectsToSpawn.Length > 0)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);

            if (objectsToSpawn[randomIndex] != null)
            {
                Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("One of the spawnable objects is not assigned.");
            }
        }
        else
        {
            Debug.LogWarning("No objects to spawn are assigned.");
        }
    }

    // Метод для установки случайного интервала
    void SetRandomSpawnInterval()
    {
        // Уменьшаем минимальный и максимальный интервалы в зависимости от прошедшего времени
        float currentMinSpawnInterval = Mathf.Max(0.2f, initialMinSpawnInterval - elapsedTime * intervalDecreaseRate);
        float currentMaxSpawnInterval = Mathf.Max(0.5f, initialMaxSpawnInterval - elapsedTime * intervalDecreaseRate);

        // Генерируем случайное значение в новом диапазоне
        currentSpawnInterval = Random.Range(currentMinSpawnInterval, currentMaxSpawnInterval);
        Debug.Log($"Next spawn interval: {currentSpawnInterval}");
    }
}
