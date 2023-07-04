using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private float baseSpeed;
    void Start()
    {
        baseSpeed= moveSpeed;
        target = LevelManager.main.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                EndPath();
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];

            }
            
        }
    }
    private void FlipEnemy()
    {

        // Calculate the direction vector from the next point to the current point
        Vector3 direction = ((target.position - transform.position)).normalized;

        // Rotate the enemy to face the new direction
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position);
        rb.velocity = direction.normalized * moveSpeed;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);

        //rb.transform.up = target.position;
    }
    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed= newSpeed;
    }
    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }

    void EndPath()
    {
        LevelManager.Lives--;
        Destroy(gameObject);
    }
}
