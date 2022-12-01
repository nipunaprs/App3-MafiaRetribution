using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMission4 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public GameManagerMission4 gameManager;


    //Animations
    public Animator animator;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenWalks;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Dead
    bool dead;

    //Health
    public float health;

    private void Awake()
    {
        player = GameObject.Find("Player (1)").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check in sight and attack range

        if (!dead)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }


    }

    private void Patroling()
    {
        animator.SetBool("run", false);
        animator.SetBool("aggressive", false);
        if (GetComponent<EnemyShootMission4>().attack) GetComponent<EnemyShootMission4>().attack = false;

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            //Play walking animation
            agent.SetDestination(walkPoint);
            animator.SetBool("walk", true);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;


        //If reached desired walk point, walk point set is false
        if (distanceToWalkPoint.magnitude < 1f)
        {
            Invoke(nameof(ResetWalkPoint), timeBetweenWalks);
            animator.SetBool("walk", false);
            animator.SetBool("aggressive", false);
            animator.SetBool("run", false);
            //Debug.Log("Walk point reset to false -- bc reached");
            //Play idle animation
        }
    }

    private void ResetWalkPoint()
    {
        walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Ensure point chosen is in map
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }


    private void ChasePlayer()
    {
        if (GetComponent<EnemyShootMission4>().attack) GetComponent<EnemyShootMission4>().attack = false;
        animator.SetBool("walk", false);
        animator.SetBool("aggressive", false);

        animator.SetBool("run", true);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy stays in place
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        animator.SetBool("run", false);
        animator.SetBool("walk", false);
        animator.SetBool("aggressive", true);
        if (!GetComponent<EnemyShootMission4>().attack) GetComponent<EnemyShootMission4>().attack = true;

        if (!alreadyAttacked)
        {
            //ATTACK CODE


            animator.SetBool("aggressive", false);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        //if (GetComponent<EnemyShoot>().attack) GetComponent<EnemyShoot>().attack = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //Play take damage animation

        if (health <= 0)
        {
            dead = true;
            //Increase money
            gameManager.KilledEnemy();

            //Play death animation
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
            animator.SetBool("aggressive", false);
            animator.SetTrigger("death");


            //Invoke destroy in a bit
            Invoke(nameof(DestroyEnemy), 4f); // Tweak timing to match animation
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
