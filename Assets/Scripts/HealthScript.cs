using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        // Проверьте, умер ли объект
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Реализуйте логику смерти объекта
        Debug.Log(gameObject.name + "Die");
        gameObject.SetActive(false); // Пример: Отключение объекта
    }
}
