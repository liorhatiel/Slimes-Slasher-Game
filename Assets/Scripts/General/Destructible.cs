using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject destroyEffectParticle;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SwordDamage>())
        {
            // Play the Destruction particle.
            Instantiate(destroyEffectParticle, transform.position, Quaternion.identity);

            // Destroy the game object.
            Destroy(gameObject);
        }
    }

}
