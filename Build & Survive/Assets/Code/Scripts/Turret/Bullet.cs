using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform target;
    private int bulletLV = 1;

    private void Awake()
    {
        bulletLV = 1;   
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        CalculateHitpoint();
    }

    private int CalculateHitpoint()
    {
        switch (bulletLV)
        {
            case 1:
                return bulletDamage *= 1;
            case 2:
                return bulletDamage *= 2;
            case 3:
                return bulletDamage *= 4;
            default:
                return bulletDamage;
        }
    }

    public void LVUpBullet()
    {
        bulletLV++;
        Debug.Log("BulletLV is: " +  bulletLV);
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;

        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

    
}
