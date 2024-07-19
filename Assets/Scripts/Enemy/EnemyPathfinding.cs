using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    public bool getKnockedBack;

    Rigidbody2D rb;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (getKnockedBack) return;
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }


    // We use this funcion to declare the value on moveDirection Vector.
    // We set the direction of the moveDirection Vector on our EnemyAI script.
    public void MoveTo(Vector2 targetPosition)
    {
        moveDirection = targetPosition;             // Our moveDirection Vector is equal to the target position of the enemy.
    }



}
