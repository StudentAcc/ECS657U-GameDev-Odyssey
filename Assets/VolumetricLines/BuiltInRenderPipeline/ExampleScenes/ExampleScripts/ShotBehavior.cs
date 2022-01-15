using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;

    GunCombat combat;
    RaycastHit hit;

    void Start()
    {
        combat = GetComponent<GunCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                //Ray ray = new Ray(transform.position, Vector3.up);

                //if (Physics.Raycast(ray, out hit))
                //{
                //    Debug.Log("Clicked on " + hit.transform.name);
                //}
                //else
                //{
                //    Debug.Log("Nothing hit");
                //}

                //CharacterStats targetStats = hit.transform.GetComponent<CharacterStats>();
                
                //if (targetStats != null)
                //{
                //    combat.Attack(targetStats);
                //}
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }

    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void explode()
    {
        //if (collisionExplosion != null)
        //{
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        //}
    }

}