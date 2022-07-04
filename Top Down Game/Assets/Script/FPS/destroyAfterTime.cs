using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    public GameObject destroyableGameObject; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(destroyableGameObject, 6);
        
    }
}
