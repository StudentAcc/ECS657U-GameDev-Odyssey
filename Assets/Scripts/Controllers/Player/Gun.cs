using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    GunCombat combat;
    PlayerInputActions controls;
    //PlayerManager playerManager;

    // Update is called once per frame

    void Start()
    {
        //playerManager = playerManager.instance;
        combat = GetComponent<GunCombat>();
    }

    void Awake()
    {
        controls = new PlayerInputActions();
    }

    private void Update()
    {
        if(controls.Player.Shoot.triggered)
        {
            Shoot();
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
                //combat.Attack(targetStats);
                combat.Attack(targetStats);
            }


            //Target target = hit.transform.GetComponent<Target>();
            //if(target != null)
            //{
            //    target.TakeDamage(damage);
            //}
        }
    }

    public void OnEnable() {
        controls.Player.Shoot.Enable();
    }

    public void OnDisable() {
        controls.Player.Shoot.Disable();
    }

}
