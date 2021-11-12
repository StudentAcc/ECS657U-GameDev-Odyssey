using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public ParticleSystem attackAnimationParticles;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            //Debug.Log("2");
            if (distance - 1 <= agent.stoppingDistance)
            { 

                //Attack the target
                //Debug.Log("1");
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                //if (combat == null)
                //{
                //    Debug.Log(combat);
                //} else
                //{
                //    Debug.Log(combat);
                //}
                if (targetStats != null)
                {
                    attackAnimationParticles.Play();
                    combat.Attack(targetStats);
                }

                // Face the arget
                FaceTarget();

            }
        }
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
