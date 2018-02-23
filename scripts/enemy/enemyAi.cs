using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAi : MonoBehaviour
{
	[SerializeField]private float speed;
	[SerializeField]private float range;
	private Transform target;
	private NavMeshAgent agent;
	private Vector3 direction;
    private enemyShoot enemyShoot;
    private bool lineOfSight(Transform target, Transform enemy)
	{
		Debug.DrawRay(transform.position, direction, Color.red);
		direction = target.position - transform.position;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, direction, out hit, range) && hit.collider.name == "Player")
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	private bool inRange(Transform target, Transform enemy)
	{
		float x = target.position.x - enemy.position.x;
		float y = target.position.z - enemy.position.z;
		float distence = Mathf.Sqrt ((x * x)+(y * y));
		if (distence < range)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void Start()
	{
		agent = GetComponent<NavMeshAgent> ();
        target = GameObject.Find("Player").transform;
        enemyShoot = GetComponent<enemyShoot>();

    }
	void Update ()
	{
		agent.SetDestination (target.position);
		if (inRange(target,transform)) 
		{//inrange
            if (lineOfSight(target, transform))
            {
                agent.speed = speed / 1.5f;
                agent.updateRotation = false;
                transform.LookAt(new Vector3(target.position.x, 0, target.position.z));
                enemyShoot.ShootCheck();
            }
            else
            {
                agent.updateRotation = true;
            }
		}
		else //out range
		{
			agent.speed = speed;
		}
	}
}
