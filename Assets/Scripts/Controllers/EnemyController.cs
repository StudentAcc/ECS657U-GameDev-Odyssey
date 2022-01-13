using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public ParticleSystem attackAnimationParticles;
    public bool wandering = true;
    public Vector3 centrePoint = new Vector3(1000f, 150f, 1000f);
    public Vector3 boundaryPoint = new Vector3(0, 150f, 2000);
    public float agroTimeLimit = 5f;

    float baseLookRadius;
    Vector3 wanderPoint;
    Vector3 lastTargetPoint;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    bool idle;

    // Start is called before the first frame update
    void Start()
    {
        baseLookRadius = lookRadius;
        wanderPoint = new Vector3(Random.Range(centrePoint.x, boundaryPoint.x), 150, Random.Range(centrePoint.z, boundaryPoint.z));
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            lastTargetPoint = target.position;
            SetDestination(lastTargetPoint);
            idle = false;
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
                    attackAnimationParticles.Play();
                }

                // Face the arget
                FaceTarget();

            }
        } else if (wandering) {

            if (idle == false && (Vector3.Distance(lastTargetPoint, transform.position) - 1 <= agent.stoppingDistance))
            {
                idle = true;
                SetDestination(wanderPoint);
                Debug.Log("log1" + idle.ToString());
            }
            else if (idle)
            {
                float distanceWander = Vector3.Distance(wanderPoint, transform.position);
                if (distanceWander - 1 <= agent.stoppingDistance || !(agent.hasPath))
                {
                    //Debug.Log("log2");
                    wanderPoint = new Vector3(Random.Range(centrePoint.x, boundaryPoint.x), 150, Random.Range(centrePoint.z, boundaryPoint.z));
                    SetDestination(wanderPoint);
                    //Debug.Log(wanderPoint);
                }
                //Debug.Log("log3");
                //Debug.Log(wanderPoint);
                //Debug.Log(transform.position);
            }
        }
    }

    void SetDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        Debug.Log(targetDestination);
        if (NavMesh.SamplePosition(targetDestination, out hit, 1000f, NavMesh.AllAreas))
        {
            //Debug.Log("hit");
            agent.SetDestination(hit.position);
            //Debug.Log(agent.pathPending);
            //Debug.Log(agent.hasPath);
            wanderPoint = hit.position;
        }
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void DamageTaken()
    {
        //lookRadius = 2000f;
        StartCoroutine(LookRadiusBuff(2000, agroTimeLimit));
        //lookRadius = baseLookRadius;
    }

    IEnumerator LookRadiusBuff(float lookRadiusBuff, float Duration)
    {
        lookRadius = lookRadiusBuff;
        yield return new WaitForSeconds(Duration);
        lookRadius = baseLookRadius;
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
