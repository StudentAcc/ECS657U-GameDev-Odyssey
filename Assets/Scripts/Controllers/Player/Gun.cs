using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public float range = 500f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    GunCombat combat;
    PlayerInputActions controls;
    [SerializeField] Pickup pickup;
    public GameObject PauseMenu;

    bool shoot;

    void Start()
    {
        combat = GetComponent<GunCombat>();
    }

    private void Update()
    {
        if(shoot)
        {
            if (!pickup.pickedup)
            {
                if(!PauseMenu.activeInHierarchy)
                {
                    GameObject.Find("OxygenBackground").GetComponent<CountDown>().onShootDecreaseOxygen();
                    Shoot();
                }
            }
            shoot = false;
        }
    }

    public void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            CharacterStats targetStats = hit.transform.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                combat.Attack(targetStats);
            }
        }
    }

    public void OnShootPressed()
    {
        shoot = true;
    }

}
