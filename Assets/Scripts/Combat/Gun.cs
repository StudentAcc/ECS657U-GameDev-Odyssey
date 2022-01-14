using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1000f;

    bool shoot;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            Shoot();
        }
        shoot = false;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    public void OnShootPressed()
    {
        shoot = true;
    }
}
