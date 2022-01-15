using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public ParticleSystem attackAnimationParticles;
    public bool wandering = true;
    public Vector3 boundaryPointS = new Vector3(1000f, 150f, 1000f);
    public Vector3 boundaryPointL = new Vector3(0, 150f, 2000);
    public float agroTimeLimit = 5f;
    public Animator anim;

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
        anim = GetComponentInChildren<Animator>();
        baseLookRadius = lookRadius;
        wanderPoint = getRandomCoordinate();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(delay(1f));
        anim.SetFloat("vertical", (agent.velocity.magnitude / agent.speed));
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
                    anim.SetBool("attack", true);
                    combat.Attack(targetStats);
                    attackAnimationParticles.Play();
                    StartCoroutine(delay(2));

                }

                // Face the arget
                FaceTarget();

            } else
            {
                anim.SetBool("attack", false);
            }
        }
        else if (wandering)
        {

            if ((idle == false && (Vector3.Distance(lastTargetPoint, transform.position) - 10 <= agent.stoppingDistance)))
            {
                StartCoroutine(delay(1f));
                idle = true;
                SetDestination(wanderPoint);
               // Debug.Log("log1" + idle.ToString());
            }
            else if (idle)
            {
                float distanceWander = Vector3.Distance(wanderPoint, transform.position);
                if (distanceWander - 15 <= agent.stoppingDistance || !(agent.hasPath))
                {
                    //Debug.Log("log2");
                    wanderPoint = getRandomCoordinate();
                    SetDestination(wanderPoint);
                    //Debug.Log(wanderPoint);
                }
                //Debug.Log("log3");
                //Debug.Log(wanderPoint);
                //Debug.Log(transform.position);
            }
        }
    }

    Vector3 getRandomCoordinate()
    {
        Vector3 randomCoord = new Vector3(0,0,0);
        bool valid = false;
        //NavMeshPath path = new NavMeshPath();
        //RaycastHit hit = new RaycastHit();
        while (!valid)
        {
            //randomCoord = new Vector3(Random.Range(boundaryPointS.x, boundaryPointL.x), 500, Random.Range(boundaryPointS.z, boundaryPointL.z));
            randomCoord = (Random.insideUnitSphere * 50) + transform.position;
            
            if (boundaryPointS.x < randomCoord.x && randomCoord.x < boundaryPointL.x && boundaryPointS.z < randomCoord.z && randomCoord.z < boundaryPointL.z)
            {
                //if (agent.CalculatePath(randomCoord, path))
                //{
                valid = true;
                //}
            }
            //Debug.Log("start");
            //Debug.Log(boundaryPointS.x);
            //Debug.Log(boundaryPointS.z);
            //Debug.Log(boundaryPointL.x);
            //Debug.Log(boundaryPointL.z);
            //Debug.Log(randomCoord);
            //Debug.Log(boundaryPointS.x < randomCoord.x);
            //Debug.Log(randomCoord.x < boundaryPointL.x);
            //Debug.Log(boundaryPointS.z < randomCoord.z);
            //Debug.Log(randomCoord.z < boundaryPointL.z);
            //valid = true;
            //Ray ray = new Ray(randomCoord, Vector3.down);
            //valid = Physics.Raycast(ray, out hit, 500, LayerMask.GetMask("Ground"));
        }
        //Debug.Log("hit");
        //Debug.Log(randomCoord);
        //return hit.point;
        return randomCoord;
    }

    void SetDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        //Debug.Log(targetDestination);
        if (NavMesh.SamplePosition(targetDestination, out hit, 50f, NavMesh.AllAreas))
        {
            //Debug.Log("hit");
            agent.SetDestination(hit.position);
            //Debug.Log(agent.pathPending);
            //Debug.Log(agent.hasPath);
            wanderPoint = hit.position;
        }
    }

    void FaceTarget()
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

    IEnumerator delay(float Duration)
    {
        yield return new WaitForSeconds(Duration);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}