using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customBullet : MonoBehaviour
{
    //Assignables//
    public Rigidbody rBody;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //Stats//
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;

    //Damage//
    public int explosionDamage;
    public float explosionRange;

    //Lifetime before explosion//
    public int maxCollissions;
    public float maxLifetime;
    public bool explosionOnTouch = true;

    int collissions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        SetUp(); 
    }

    private void Update()
    {
        //When  to explode:
        if (collissions > maxCollissions) Explode();

        //Count down lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode(); 
    }

    private void Explode() 
    {
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Don't count collissions with other bullets//
        // if (collision.collider.CompareTag("Bullet")) return;

        //Count up collisions
        collissions++;

        //Explode if bullet hits enemy directly and explodeOnTouch is activated
        if (collision.collider.CompareTag("Enemy") && explosionOnTouch) Explode();
        //STOPPED//
    }

    private void SetUp() 
    {
        //Create a new Physic material// 
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        //Assign material to collider//
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity//
        rBody.useGravity = useGravity;
    }
}
