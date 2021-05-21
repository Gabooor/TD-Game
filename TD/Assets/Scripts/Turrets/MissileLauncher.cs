using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{

    public Transform target;
    int shotNumber = 0;

    private float range = 25f;
    private float fireRate = 8f;
    private float fireCountdown = 0f;
    private float turnSpeed = 10f;
    private bool isReadToFire = true;
    private float coolDown = 3f;
    private string enemyTag = "Enemy";

    [Header("Unity Setup Fields")]
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    public Transform firePoint8;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (isReadToFire == true)
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        if (isReadToFire == false)
        {
            if(coolDown > 0f)
            {
                coolDown -= Time.deltaTime;
            }
            else
            {
                if(coolDown <= 0f)
                {
                    isReadToFire = true;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bulletGO;
        Bullet bullet;
        switch (shotNumber)
        {
            case 0:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 1:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 2:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 3:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 4:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 5:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint6.position, firePoint6.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 6:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint7.position, firePoint7.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber++;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                break;
            case 7:
                bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint8.position, firePoint8.rotation);
                bullet = bulletGO.GetComponent<Bullet>();
                shotNumber = 0;
                if (bullet != null)
                {
                    bullet.Seek(target);
                }
                coolDown = 3;
                isReadToFire = false;
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
