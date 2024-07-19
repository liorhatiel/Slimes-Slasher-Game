using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int startHealth;
    [SerializeField] int currentHealth;
    [SerializeField] int startMana;
    [SerializeField] int currentMana;


    public static int playerHealth;
    public static int playerMana;

    // Start is called before the first frame update
    void Start()
    {
        startHealth = 100;
        currentHealth = startHealth;
        startMana = 100;
        currentMana = startMana;


    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = currentHealth;
        playerMana = currentMana;
    }
}
