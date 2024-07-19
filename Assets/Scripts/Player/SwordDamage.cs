using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] int swordDamagePower;

    EnemyPathfinding enemyPathfinding;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Create new "EnemyHealth" class so we can approach to the "TakeDamage()" funcion.
            // All the Enemies contains that "EnemyHealth" class. We use that class to make damage TO EVERY ENEMY in our scene.
            // Each enemy conatins seperate EnemyHealth script. So each enemy have HIS OWN LIFE.
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(swordDamagePower);                                // Using the "TakeDamage" funcion in that class.

        }
    }

}
