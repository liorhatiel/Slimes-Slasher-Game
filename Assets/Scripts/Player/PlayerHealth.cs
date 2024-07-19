using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int startHealth;
    [SerializeField] int currentHealth;

    void Start()
    {
        startHealth = 100;
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentHealth -= damage;
        }
    }
}
