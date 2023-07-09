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

        // Tính toán góc quay của viên đạn để hướng đi theo target
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Sử dụng Coroutine để xoay từ góc hiện tại sang góc mới một cách mượt mà
        StartCoroutine(RotateTowardsTarget(angle - 90f, rotationSpeed)); // Đổi ở đây

        // Đảo chiều mũi tên để nó hướng lên trên
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

        // Bắt đầu di chuyển theo target sau khi hoàn thành xoay
        rb.velocity = transform.up * bulletSpeed;
    }

    private void FixedUpdate()
    {
        if (!target)
            return;

        // Thay đổi dòng này để lấy hướng chính xác từ mũi tên
        Vector2 direction = transform.up;

        rb.velocity = direction * bulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }


}
