using UnityEngine;
using UnityEngine.EventSystems;

public class GunController : MonoBehaviour
{

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
        if (shoot)
        {
            if (!PauseMenu.activeInHierarchy && !ControlsMenu.activeInHierarchy)
            {
                m_animator.SetTrigger("Shoot");
            }
            shoot = false;
        }
    }

    public void OnShootPressed()
    {
        shoot = true;
    }

}
