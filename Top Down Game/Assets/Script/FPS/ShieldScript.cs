using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public Transform trans; // where the object will instantiate
    public Rigidbody shieldGameObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Rigidbody bulletShield;
            bulletShield = Instantiate(shieldGameObj, trans.position, trans.rotation);
        } 
    }
}
