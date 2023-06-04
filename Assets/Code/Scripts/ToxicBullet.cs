using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 2f;
    [SerializeField] private int bulletDamage = 2;
    [SerializeField] private float splashRange = 1;
    [SerializeField] private float damageOverTimeDuration = 3f;
    [SerializeField] private float damageOverTimeInterval = 0.5f;
    [SerializeField] private int damageOverTimeAmount = 1;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;

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
                StartCoroutine(TakeDamageOverTime(health));
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator TakeDamageOverTime(Health health)
    {
        float timeElapsed = 0f;
        while (timeElapsed < damageOverTimeDuration)
        {
            yield return new WaitForSeconds(damageOverTimeInterval);
            health.TakeDamage(damageOverTimeAmount);
            timeElapsed += damageOverTimeInterval;
        }
    }
}