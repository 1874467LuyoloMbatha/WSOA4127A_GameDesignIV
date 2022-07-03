using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player; // player detection 

    public LayerMask whatIsGround, whatIsPlayer;

    //Health SetUp
   public float health; 

    //Patroling//
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking//
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile; 

    //States//
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("P1").transform;
        agent = GetComponent<NavMeshAgent>(); // attached to enemy object 
    }

    private void Update()
    {
        //Check for sight and attack range//
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); 
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasingPlayer();
        if (playerInSightRange && playerInAttackRange) AttackingPLayer(); 
    }

    private void Patroling() 
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached//
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void ChasingPlayer()
    {
        agent.SetDestination(player.position); 
    }

    private void AttackingPLayer()
    {
        //Make sure enemy is not moving//
        agent.SetDestination(player.position);

        transform.LookAt(player);

        if (!alreadyAttacked) 
        {
            //Attack code goes her//
            Rigidbody rBody = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
           
            rBody.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rBody.AddForce(transform.up * 8f, ForceMode.Impulse);
            //

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range//
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; 
    }

    private void ResetAttack() 
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
         

    } //ended @4:19//

    private void DestroyEnemy()
    {
        Destroy(gameObject); 
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange); 
    }
}
