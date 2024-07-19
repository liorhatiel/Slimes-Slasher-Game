using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] GameObject slimeDeathEffect;

    Knockback knockback;
    Flash flash;

    private int currentHealth;


    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        flash = GetComponent<Flash>();
    }

    void Start()
    {
        currentHealth = startingHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if( currentHealth <= 0 )
        {
            Die();
        }
        knockback.TakeKnockBack();
        StartCoroutine(flash.WhiteFlashRoutine());
    }


    void Die()
    {
        Instantiate(slimeDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

  

   

    

}
