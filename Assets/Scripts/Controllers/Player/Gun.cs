using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public float range = 500f;

    public Camera fpsCam;

    GunCombat combat;
    PlayerInputActions controls;
    [SerializeField] Pickup pickup;
    public GameObject PauseMenu;

    Animator m_animator;

    bool shoot;

    void Start()
    {
        combat = GetComponent<GunCombat>();
        m_animator = GetComponent<Animator>();
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
                    m_animator.SetTrigger("Shoot");
                }
            }
            shoot = false;
        }
    }

    public void Shoot()
    {
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
