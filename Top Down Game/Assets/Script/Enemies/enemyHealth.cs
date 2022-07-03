using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        
        
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
        
        } //stopped @ 2:02
       
        
    
    }
}
