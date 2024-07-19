using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float knockbackForce = 2f;
    [SerializeField] float knockbackDuration = 0.3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeKnockBack()
    {
        EnemyPathfinding enemyPathfinding = GetComponent<EnemyPathfinding>();
        SwordDamage swordDamage = FindObjectOfType<SwordDamage>();
        enemyPathfinding.getKnockedBack = true;
        rb.velocity = Vector2.zero;
        Vector2 knockbackDirection = (transform.position - swordDamage.transform.position).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(EndKnockBack());
    }

    private IEnumerator EndKnockBack()
    {
        yield return new WaitForSeconds(knockbackDuration);
        EnemyPathfinding enemyPathfinding = GetComponent<EnemyPathfinding>();
        enemyPathfinding.getKnockedBack = false;
        rb.velocity = Vector2.zero; // Stop the knockback effect
    }
}
