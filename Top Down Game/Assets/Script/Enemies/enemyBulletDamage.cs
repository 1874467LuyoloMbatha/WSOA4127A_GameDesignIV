using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletDamage : MonoBehaviour
{
    //Damage//
    public int bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Where player takes damage from bullet//
        if (collision.gameObject.TryGetComponent<playerHealth>(out playerHealth playerComponent)) 
        {
            playerComponent.TakeDamage(bulletDamage);
        
        }
    }
}
