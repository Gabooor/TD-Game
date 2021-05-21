using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed = 4f;
    private int wavepointIndex = 0;
    private Transform target;

    public int health = 100;

    public int value = 25;

    void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Level1.totalEnemyCount--;
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (target)
        {
            dir.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 7.5f * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            ReachedEnd();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void ReachedEnd()
    {
        Level1.totalEnemyCount--;
        PlayerStats.Health--;
        Destroy(gameObject);
    }
}
