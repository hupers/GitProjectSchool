using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZlayaCorobkaScript : MonoBehaviour
{
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
