using UnityEngine;
using UnityEngine.EventSystems;

public class RayGun : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;
    public Camera fpsCam;

    public GameObject PauseMenu;
    bool shoot;


    private void Update()
    {
        if(shoot)
        {
            if(!PauseMenu.activeInHierarchy)
            {
                Shoot();
                m_shootRateTimeStamp = Time.time + shootRate;
                shoot = false;
            }
        }
    }

    public void Shoot()
    {

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
    }

    public void OnShootPressed()
    {
        shoot = true;
    }

}
