using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMoveFlyingPatrolChase : MonoBehaviour
{

    // public references for patrol points
    public GameObject[] patrolPoints;

    // Current patroll point index
    private int currentPatrolPointIndex = 0;

    //variable for movement 
    public float speed = 2f;
    public float chaseRange = 3f;

    // Enemy state enum
    public enum EnemyState { PATROLLING, CHASING}

    //current enemy state
    public EnemyState currentState = EnemyState.PATROLLING;

    public GameObject target;

    private GameObject player;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

   
    // Start is called before the first frame update
    void Start()
    {
        // Find Player
        player = GameObject.FindWithTag("Player");

        //Get the rigidbody2D component of enemy
        rb = GetComponent<Rigidbody2D>();

        //Get the sprite Renderer component of enemy
        sr = GetComponent<SpriteRenderer>();

        //Check if patrol points are assigned
        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("No patorl points assigned");
        }

        //Set inital target to first patrol point
        target = patrolPoints[currentPatrolPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //Update state bassed on player and target distatance
        UpdateState();

        // Move and face based on curret state
        switch (currentState)
        {
            case EnemyState.PATROLLING:
                Patrol();
                break;
            case EnemyState.CHASING:
                ChasePlayer();
                break;
            default:
                Debug.LogError("Invalid currentState on enemy Octopus");
                break;
        }

        //you can use debug.drawline to draw  a line between the two points in scene view
        Debug.DrawLine(transform.position, target.transform.position, Color.red);
    }

    // Update enemy stat based on player poximity
    void UpdateState()
    {
        if(IsPlayerInChaseRange() && currentState == EnemyState.PATROLLING)
        {
            currentState = EnemyState.CHASING;
        }
        else if (!IsPlayerInChaseRange() && currentState == EnemyState.CHASING)
        {
            currentState = EnemyState.PATROLLING;
        }
    }
    bool IsPlayerInChaseRange()
    {
        if (player == null)
        {
            Debug.LogError("Player not found");
            return false;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= chaseRange;
    }

    void Patrol()
    {
        // check if reached current target
        if(Vector2.Distance(transform.position, target.transform.position) <= 0.5f)
        {
            // update target to next patrol point (wrap around)
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        // set target to current patrol point
        target = patrolPoints[currentPatrolPointIndex];

        MoveTowardsTarget();
    }
    void ChasePlayer()
    {
        target = player;
        MoveTowardsTarget();
    }
    void MoveTowardsTarget()
    {
        //Calculate direction towards target
        Vector2 direction = target.transform.position - transform.position;

        // Normalize direction
        direction.Normalize();

        //Move towards target with rb
        rb.velocity = direction * speed;

        //face foward
        FaceFoward(direction);
    }

    private void FaceFoward(Vector2 direction)
    {
        if (direction.x < 0)
        {
            sr.flipX = false;
        }
        else if (direction.x > 0)
        {
            sr.flipX = true;
        }
    }

    // draw circles for patrol points in scene view
    private void OnDrawGizmos()
    {
       if(patrolPoints != null)
        {
            Gizmos.color = Color.green;
            foreach(GameObject point in patrolPoints)
            {
                Gizmos.DrawWireSphere(point.transform.position, 0.5f);
            }
        }
    }
}
