using UnityEngine;
using UnityEngine.EventSystems;

public class GunController : MonoBehaviour
{

    public int damage = 10;
    public float range = 100f;
    public float fireRate;
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public GameObject PauseMenu;
    public GameObject ControlsMenu;

    Animator m_animator;

    bool shoot;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (shoot && Time.time >= nextTimeToFire)
        {
            //if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true) //allows shooting only when the gun is in "idle" animation
            //{
            if (!PauseMenu.activeInHierarchy && !ControlsMenu.activeInHierarchy)
            {
                muzzleFlash.Play();
                    
                m_animator.SetTrigger("Shoot");
                nextTimeToFire = Time.time + 1f / fireRate;
                GameObject.Find("OxygenBackground").GetComponent<CountDown>().onShootDecreaseOxygen();
            }

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                EnemyStats enemy = hit.transform.GetComponent<EnemyStats>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);

            }
            shoot = false;
            //}
        }

    }

    public void OnShootPressed()
    {
        shoot = true;
    }
}
