using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController m_Player;

    float m_horizontal;
    float m_vertical;

    public float pSpeed; 
   
    void Start()
    {
        m_Player = GetComponent<CharacterController>(); 
        
    }

   
    void Update()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        Vector3 m_playerMovement = new Vector3(m_horizontal, 0f, m_vertical) * pSpeed;

        m_Player.Move(m_playerMovement);
    }
}
