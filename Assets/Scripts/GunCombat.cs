using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunStats))]
public class GunCombat : MonoBehaviour
{

    GunStats myStats;

    void Start()
    {
        myStats = GetComponent<GunStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        targetStats.TakeDamage(myStats.damage.GetValue());
    }

}
