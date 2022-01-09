using UnityEngine;
using UnityEngine.EventSystems;

public class GunController : MonoBehaviour
{

    public GameObject PauseMenu;

    Animator m_animator;

    bool shoot;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (shoot)
        {
            if (!PauseMenu.activeInHierarchy)
            {
                m_animator.SetTrigger("Shoot");
                GameObject.Find("OxygenBackground").GetComponent<CountDown>().onShootDecreaseOxygen();
                shoot = false;
            }
        }
    }

    public void OnShootPressed()
    {
        shoot = true;
    }

}
