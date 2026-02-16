using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Максимальное здоровье
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем начальное здоровье
    }

    // Метод для получения урона
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log($"Player Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Если здоровье закончилось, вызываем метод Die
        }
    }

    // Метод для обработки смерти игрока
    void Die()
    {
        Debug.Log("Player Died!");
        // Здесь можно добавить логику завершения игры, например:
        // SceneManager.LoadScene("GameOverScene");
        Destroy(gameObject); // Уничтожаем объект игрока
    }
}
