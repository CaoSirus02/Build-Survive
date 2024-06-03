using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private float baseSpeed;

    void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[0];
    }

    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if (LevelManager.main.startPoint)
            {
                if (pathIndex == LevelManager.main.path.Length)
                {
                    EnemySpawner.onEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    GameManager.main.playerHealth--;
                    return;
                }
                else
                {
                    target = LevelManager.main.path[pathIndex];
                }
            }
            
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized; // normalized makes 0-1

        rb.velocity = direction * moveSpeed;
    }
    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
