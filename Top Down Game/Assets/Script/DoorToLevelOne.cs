using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLevelOne : MonoBehaviour
{
    public string sceneLoader;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            SceneManager.LoadScene(sceneLoader);
        
        }
        
    }
}
