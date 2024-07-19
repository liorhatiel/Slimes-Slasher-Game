using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private enum State
    {
        Roaming // נדידה
    }


    State state;                             // Refrence to the State enum.
    EnemyPathfinding enemyPathfinding;


    private void Awake()
    {
        state = State.Roaming;                                     // On awake -> the state of the ememy is Roaming.
        enemyPathfinding = GetComponent<EnemyPathfinding>();       // Refrence to the EnemyPathfinding script.
    }

    private void Start()
    {
        StartCoroutine(RoamingRouting());
    }

    private IEnumerator RoamingRouting()
    {
        // While the state is Roaming 
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();                 // Get the roaming position of the enemy.
            enemyPathfinding.MoveTo(roamPosition);                       // We want the enemy move to the roam position - The random vector below.
            yield return new WaitForSeconds(2f);                         // Execute every 2 seconds.
        }
    }

    private Vector2 GetRoamingPosition()
    {
        //normalizing the vector ensures that the enemy will always roam at a consistent distance from its starting position.
        Vector2 roamingPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;  // Normalized = lenght is 1. Linear Algebra.
        return roamingPosition;
    }

}
