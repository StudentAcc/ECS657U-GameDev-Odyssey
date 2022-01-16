using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    // Initialise enemy controller variables
    public float lookRadius = 10f;
    public ParticleSystem attackAnimationParticles;
    public bool wandering = true;
    public Vector3 boundaryPointS = new Vector3(1000f, 150f, 1000f);
    public Vector3 boundaryPointL = new Vector3(0, 150f, 2000);
    public float agroTimeLimit = 5f;
    public Animator anim;
    public string debug;
    public int wanderLookRadius = 50;

    float baseLookRadius;
    Vector3 wanderPoint;
    Vector3 lastTargetPoint;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    bool idle;
    string prevDebug;

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
        SetDestination(wanderPoint);

        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            //Debug.Log("Easy");
            agent.speed = 12;
            lookRadius = 10;

        }
        else if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            //Debug.Log("Normal");
            agent.speed = 17;
            lookRadius = 20;

        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            //Debug.Log("Hard");
            agent.speed = 25;
            lookRadius = 40;

        }
        else
        {
            Debug.Log(PlayerPrefs.GetString("Difficulty"));
        }

        StartCoroutine(delay(3f));
        StartCoroutine(onCoroutine());

    }


    IEnumerator onCoroutine()
    {
        while (true)
        {
            //Debug.Log("OnCoroutine: " + (int)Time.time);
            agentUpdate();
            yield return new WaitForSeconds(Random.Range(1f,2f));
        }
    }

    // Update is called once per 1-2 seconds
    void agentUpdate()
    {
        //StartCoroutine(delay(Random.Range(3,5)));
        anim.SetFloat("vertical", (agent.velocity.magnitude / agent.speed));
        if (agent.isActiveAndEnabled) 
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
                        anim.SetBool("attack", true);
                        combat.Attack(targetStats);
                        attackAnimationParticles.Play();
                        //attackAnimationParticles2.Play();
                        //StartCoroutine(delay(Random.Range(0.3f,0.4f)));

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

                float distanceWander = Vector3.Distance(wanderPoint, transform.position);
                if (idle == false && Vector3.Distance(lastTargetPoint, transform.position) - 2 <= agent.stoppingDistance)
                {
                    debug = "not-idle";
                    //agent.isStopped = true;
                    agent.ResetPath();
                    StartCoroutine(delay(1f));
                    idle = true;
                    wanderPoint = getRandomCoordinate();
                    SetDestination(wanderPoint);
                   // Debug.Log("log1" + idle.ToString());
                }
                else if (idle)
                {
                    if (distanceWander - 1 <= agent.stoppingDistance)
                    {
                        debug = "idle";
                        //Debug.Log("log2");
                        //agent.isStopped = true;
                        //agent.ResetPath();
                        wanderPoint = getRandomCoordinate();
                        SetDestination(wanderPoint);
                        //Debug.Log(wanderPoint);
                    } else
                    {
                        //StartCoroutine(delay(1));
                        debug = "idle - 2 - " + distanceWander + " | " + agent.stoppingDistance + " | " ;
                        //if (debug == prevDebug)
                        //{
                        //    debug = "idle - 3 - " + distanceWander + " | " + agent.stoppingDistance + " | ";
                        //    //agent.isStopped = true;
                        //    //agent.ResetPath();
                        //    wanderLookRadius *= 4;
                        //    wanderPoint = getRandomCoordinate();
                        //    SetDestination(wanderPoint);
                        //    wanderLookRadius /= 4;
                        //}

                        //prevDebug = debug;
                        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
                        {
                            debug = "idle - 3 - " + distanceWander + " | " + agent.stoppingDistance + " | ";
                            wanderPoint = getRandomCoordinate();
                            SetDestination(wanderPoint);
                        }
                    }
                    //Debug.Log("log3");
                    //Debug.Log(wanderPoint);
                    //Debug.Log(transform.position);
                }
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
            
            if (transform.position.x < boundaryPointS.x)
            {
                randomCoord.x += boundaryPointS.x - transform.position.x;
            } else if (transform.position.z < boundaryPointS.z) {
                randomCoord.z += boundaryPointS.z - transform.position.z;
            }
            
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