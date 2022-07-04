using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    public int currentHealth;
    public int maxHealth;

    public Slider slider; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        slider.value = currentHealth;
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            //Destroy(gameObject); // player dies.  
            restartGame();
        }
    }

    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
