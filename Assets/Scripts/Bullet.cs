using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
            Destroy(collision.gameObject);
            Destroy(gameObject);
    }
    public float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // Проверьте, что объект, который мы столкнулись, имеет компонент Health
        if (other.GetComponent<HealthScript>() != null)
        {
            // Нанесите урон
            other.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }

}
