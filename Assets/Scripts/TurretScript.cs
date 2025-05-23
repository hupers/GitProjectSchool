using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;

    [Header("Bullet settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform [] gunBarrel;    // стволи
    [SerializeField] private float countdown;   // перезарядка
    private bool isSecondBarrel;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target);

            if(canShoot)
            {
                if(isSecondBarrel)
                {
                    StartCoroutine(Shoot(0));
                }
                else
                {
                    StartCoroutine(Shoot(1));
                }
                canShoot = !canShoot;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void FindTarget()
    {
        GameObject [] targets = GameObject.FindGameObjectsWithTag("Player");
        GameObject currentTarget = null;

        float distance = Mathf.Infinity;

        foreach(GameObject target in targets)
        {
            float distanceToEnemy = 
                Vector3.Distance(transform.position, target.transform.position);
            
            if(distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                currentTarget = target;     // визначаємо ворога турелі
            }

            if(distance <= range && currentTarget != null)
            {
                this.target = currentTarget.transform;
            }
            else
            {
                this.target = null;
            }
        }
    }
    IEnumerator Shoot(int barrelNumber)
    {
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel[barrelNumber]);
        bullet.GetComponent<bullet1>().TakeForce(target);
        bullet.transform.SetParent(null);
        isSecondBarrel = !isSecondBarrel;

        yield return new WaitForSeconds(countdown);
        canShoot = !canShoot;
    }
}
