using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Atribute")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform target;

    public void SetTarget(Transform _target, float rotationSpeed)
    {
        target = _target;

        // T�nh to�n g�c quay c?a vi�n ??n ?? h??ng ?i theo target
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // S? d?ng Coroutine ?? xoay t? g�c hi?n t?i sang g�c m?i m?t c�ch m??t m�
        StartCoroutine(RotateTowardsTarget(angle - 90f, rotationSpeed)); // ??i ? ?�y

        // ??o chi?u m?i t�n ?? n� h??ng l�n tr�n
        transform.Rotate(0f, 0f, -90f);
    }

    private IEnumerator RotateTowardsTarget(float targetAngle, float rotationSpeed)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);

        float elapsedTime = 0f;
        while (elapsedTime < 1f / rotationSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / (1f / rotationSpeed));

            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        // B?t ??u di chuy?n theo target sau khi ho�n th�nh xoay
        rb.velocity = transform.up * bulletSpeed;
    }

    private void FixedUpdate()
    {
        if (!target)
            return;

        // Thay ??i d�ng n�y ?? l?y h??ng ch�nh x�c t? m?i t�n
        Vector2 direction = transform.up;

        rb.velocity = direction * bulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }


}
