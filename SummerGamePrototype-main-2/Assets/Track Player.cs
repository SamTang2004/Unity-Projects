using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{

    public Transform Target;
    public float UpdateSpeed = 0.1f;

    private NavMeshAgent Agent;
    float speed;

    // Start is called before the first frame update

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        speed = Agent.speed;
        StartCoroutine(FollowTarget());
    }

    // Update is called once per frame
    private IEnumerator FollowTarget()
    {
        while (enabled)
        {
            float update = (this.transform.position - Target.transform.position).magnitude;
            if (update > 5.0f && update < 40.0f)
            {
                Agent.speed = speed;
                Agent.SetDestination(Target.transform.position);
                Debug.Log("dsadsaa");
            }
            else
            {
                Agent.speed = 0f;
            }
            yield return new WaitForSeconds(UpdateSpeed);
        }
    }
}