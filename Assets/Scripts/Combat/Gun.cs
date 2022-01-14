using UnityEngine;

public class Gun : MonoBehaviour
{
    //initialises damage and range of gun
    public float damage = 10f;
    public float range = 1000f;

    //initialises shoot variable to determine if user will shoot
    bool shoot;
    
    //initialises camera for Raycast so that game knows where user is aiming
    public Camera fpsCam;

    //if user has clicked the "shoot" button, game will run the 'Shoot()' method and set shoot back to false
    void Update()
    {
        if (shoot)
        {
            Shoot();
        }
        shoot = false;
    }

    //method that shoots the weapon via the use of Raycast
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //if the player is aiming at an enemy, then make the enemy take damage
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    //setter methd that sets the 'shoot' boolean to 'true'
    public void OnShootPressed()
    {
        shoot = true;
    }
}
