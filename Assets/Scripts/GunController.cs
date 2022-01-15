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

    public GameObject fireSound;
    public AudioSource fireSource;
    public GameObject Audio;

    public GameObject VolumeMenu;
    public GameObject PauseMenu;
    public GameObject ControlsMenu;

    public int gunUpgrade = 0;

    Animator m_animator;

    bool shoot;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        InstantiateAudio(fireSound.GetComponent<AudioSource>().clip);
    }



    private void Update()
    {
        if (gunUpgrade == 1)
        {
            fireRate = 3f;
        }

        if (gunUpgrade == 3)
        {
            fireRate = 50f;
        }

        if (shoot && Time.time >= nextTimeToFire)
        {
            //if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true) //allows shooting only when the gun is in "idle" animation
            //{
                if (!PauseMenu.activeInHierarchy && !ControlsMenu.activeInHierarchy && !VolumeMenu.activeInHierarchy)
                {

                    if (gunUpgrade == 3)
                    {
                        m_animator.SetBool("AutoShoot", true);
                    }
                    else
                    {
                        m_animator.SetTrigger("Shoot");
                    }
                        
                    nextTimeToFire = Time.time + 1f / fireRate;



                    if (gunUpgrade < 2)
                    {
                        GameObject.Find("OxygenBackground").GetComponent<CountDown>().onShootDecreaseOxygen();
                    }

                    RaycastHit hit;
                    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
                    {
                        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, 2f);

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

                        

                    }
                }
                if (gunUpgrade < 3)
                { 
                    shoot = false; 
                }
            //}
        } else
        {
            m_animator.SetBool("AutoShoot", false);
        }

    }


    private void InstantiateAudio(AudioClip clip)
    {
        fireSource = gameObject.AddComponent<AudioSource>();
        fireSource.clip = clip;
    }

    public void playSound()
    {
        fireSource.volume = Audio.GetComponent<AudioManager>().getSoundEffectsVolume();
        if (fireSource.isPlaying)
        {
            fireSource.Stop();
            fireSource.Play();
        }
        else
        {
            fireSource.Play();
        }
    }

    public void OnShootPressed()
    {
        shoot = true;
    }

    public void increaseFireRate()
    {
        fireRate += 1;
    }

    public void upgradeGun()
    {
        gunUpgrade += 1;
    }

    public void OnShootHold()
    {
        Debug.Log("This should not be reapeating mate");
        shoot = true;
    }

    public void OnShootStop()
    {
        Debug.Log("you have let go of the shoot button");
        m_animator.SetBool("AutoShoot", false);
        shoot = false;
    }

    public void playMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
