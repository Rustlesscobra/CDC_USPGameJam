using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float maxSpawnDistance = 10f;
    public float maxTargetDistance = 10f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Transform enemyGFX;

    public Vector3 startingPoint;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        startingPoint = transform.position;

        InvokeRepeating("UpdatePath", 0f, .5f);        
    }

    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 10);
    }
    void UpdatePath()
    {
        if ((target.position - transform.position).magnitude >= maxTargetDistance)
        {  
            BackToStart(); 
        }
            
        
        else if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete (Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void BackToStart()
    {
        seeker.StartPath(rb.position, startingPoint, OnPathComplete);
    }

    
    void FixedUpdate()
    {           
        if (path == null)
            return;
        
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.001f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.001f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

        if (direction != Vector2.zero)
        {
            bool flipped = direction.x > 0;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f: 0f, 0f));
        }
    }
}
