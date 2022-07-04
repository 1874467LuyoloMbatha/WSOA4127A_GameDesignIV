using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField]
    public int currentHealth;
    public int maxHealth;
    


    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        
        
    }

    public void TakeDamage(int damageAmount) 
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) 
        {
            Destroy(gameObject); // enemy dies. 
        
        }
       
            
       
    }

  
}
