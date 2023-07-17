using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Atribute")]
    [SerializeField] private float bulletSpeed = 2f;
    [SerializeField] private int bulletDamage = 2;
    [SerializeField] private float splashRange = 1;

    private Transform target;
    private float targetingRange;
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void SetTargetingRangeBase(float rangeBase)
    {
        targetingRange = rangeBase;
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget >= targetingRange)
        {
            Destroy(gameObject);
            return;
        }

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
        foreach (Collider2D collider in colliders)
        {
            GameObject obj = collider.gameObject;
            Health health = obj.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(bulletDamage);
            }
        }

        Destroy(gameObject);
    }

}
